using System;
using System.Linq;
using System.Threading;
using BglReader.SourceGenerators.BinaryGenerators.Instructions;
using Microsoft.CodeAnalysis;

namespace BglReader.SourceGenerators.BinaryGenerators;

[Generator]
public sealed class BinarySerializableSourceGenerator : IIncrementalGenerator
{
    private static Func<AttributeData, bool> IsBinaryAttribute() => x =>
        x.AttributeClass?.ToDisplayString() == "BglReader.Attributes.BinaryAttributes.BinaryAttribute";

    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        context.RegisterPostInitializationOutput(ctx => ctx.AddSource("BinarySource.g.cs", """
            namespace BglReader.Attributes.BinaryAttributes;

            public interface IBinaryRecordReader<out T>
            {
                static abstract T Read(BglRecordContext context, BglBinaryReader reader);
            }

            public interface IBinaryValueReader<out T>
            {
                static abstract T Read(BglBinaryReader reader);
            }
            """));

        var classes = context.SyntaxProvider.ForAttributeWithMetadataName(
            "BglReader.Attributes.BinaryAttributes.BinarySerializableAttribute",
            static (_, _) => true,
            TransformModel);

        context.RegisterSourceOutput(classes, Execute);
    }

    private static ClassModel<BinaryProperty> TransformModel(GeneratorAttributeSyntaxContext ctx,
        CancellationToken token)
    {
        token.ThrowIfCancellationRequested();

        var typeSymbol = (INamedTypeSymbol)ctx.TargetSymbol;

        var properties = typeSymbol
            .GetMembers()
            .OfType<IPropertySymbol>()
            .Where(x => x.GetAttributes().Any(IsBinaryAttribute()))
            .Select(BuildProperty)
            .OrderBy(x => x.Order)
            .ToList();

        return new ClassModel<BinaryProperty>(
            typeSymbol, properties);
    }

    private static BinaryProperty BuildProperty(
        IPropertySymbol property)
    {
        return new BinaryProperty(
            property.Name,
            GetOrder(property),
            InstructionFactory.Create(property));
    }

    private static int GetOrder(IPropertySymbol property)
    {
        var binaryAttribute =
            property.GetAttributes().FirstOrDefault(IsBinaryAttribute());

        return binaryAttribute != null ? (int)binaryAttribute.ConstructorArguments[0].Value! : 0;
    }

    private static void Execute(SourceProductionContext ctx, ClassModel<BinaryProperty> record)
    {
        var sb = new IndentingStringBuilder();

        sb
            .AppendLine($"namespace {record.Namespace};")
            .AppendLine()
            .AppendLine(record.ToDeclaration())
            .AppendLine("{")
            .IncrementIndentation();

        sb.AppendLine(record.IsInheriting
            ? $"internal {record.Name}(ushort id, BglBinaryReader reader) : base(id, reader)"
            : $"internal {record.Name}(BglBinaryReader reader)");

        sb.AppendLine("{")
            .IncrementIndentation();

        foreach (var property in record.Properties.OrderBy(p => p.Order))
        {
            property.Instruction.Emit(property.Name, sb);
        }

        sb
            .DecrementIndentation()
            .AppendLine("}")
            .DecrementIndentation()
            .AppendLine("}");

        ctx.AddSource($"{record.Name}.g.cs", sb.ToString());
    }
}

internal sealed record BinaryProperty(
    string Name,
    int Order,
    ReadInstruction Instruction);