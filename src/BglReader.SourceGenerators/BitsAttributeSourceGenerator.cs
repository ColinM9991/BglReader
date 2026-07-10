using System.Linq;
using Microsoft.CodeAnalysis;

namespace BglReader.SourceGenerators
{
    [Generator]
    public sealed class BitsAttributeSourceGenerator : IIncrementalGenerator
    {
        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
            var classes = context.SyntaxProvider.ForAttributeWithMetadataName(
                "BglReader.Attributes.BitFieldAttribute",
                static (_, _) => true,
                static (ctx, token) =>
                {
                    token.ThrowIfCancellationRequested();

                    var attribute = ctx.Attributes[0];

                    var underlyingType = attribute.ConstructorArguments[0]
                        .Value as ITypeSymbol;

                    var typeSymbol = (INamedTypeSymbol)ctx.TargetSymbol;

                    var properties = typeSymbol
                        .GetMembers()
                        .OfType<IPropertySymbol>()
                        .Where(static x => x.GetAttributes()
                            .Any(static a =>
                                a.AttributeClass?.Name == "BitsAttribute"))
                        .Select(static property =>
                        {
                            var bits = property.GetAttributes()
                                .First(a => a.AttributeClass?.Name == "BitsAttribute");

                            return new Property(
                                property.Type.ToDisplayString(),
                                property.Type.SpecialType,
                                property.Name,
                                (int)bits.ConstructorArguments[0].Value!,
                                (int)bits.ConstructorArguments[1].Value!);
                        })
                        .ToArray();

                    return new BitField(
                        typeSymbol.Name,
                        typeSymbol.BaseType is not null && typeSymbol.BaseType.SpecialType != SpecialType.System_Object,
                        typeSymbol.ContainingNamespace.ToDisplayString(),
                        underlyingType!.ToDisplayString(),
                        properties);
                });
            context.RegisterSourceOutput(classes, Generate);
        }

        private static void Generate(
            SourceProductionContext context,
            BitField bitField)
        {
            var source = new IndentingStringBuilder();

            source.AppendLine($"namespace {bitField.Namespace};")
                .AppendLine()
                .AppendLine($"public partial class {bitField.Name}")
                .AppendLine("{")
                .IncrementIndentation()
                .AppendLine($"private readonly {bitField.UnderlyingType} _value;")
                .AppendLine()
                .AppendLine($"public {bitField.Name}({bitField.UnderlyingType} value)");

            if (bitField.IsInheriting)
            {
                source.IncrementIndentation()
                    .AppendLine(": base(value)")
                    .DecrementIndentation();
            }
            
            source.AppendLine("{")
                .IncrementIndentation()
                .AppendLine("_value = value;")
                .DecrementIndentation() 
                .AppendLine("}")
                .AppendLine();

            foreach (var property in bitField.Properties)
            {
                var mask = CreateMask(property.Length);

                source.AppendLine($"public partial {property.Type} {property.Name}")
                    .AppendLine("{")
                    .IncrementIndentation()
                    .AppendLine("get")
                    .AppendLine("{")
                    .IncrementIndentation()
                    .Append("return ");
                
                if (property.ReturnKind is not SpecialType.System_Boolean)
                    source.Append($"({property.Type})");
                
                var bitmask = property.Offset == 0 ?
                    $"(_value & {mask})"
                    : $"((_value >> {property.Offset}) & {mask})";
                
                source.Append(bitmask);
                
                if (property.ReturnKind is SpecialType.System_Boolean)
                    source.Append(" != 0");
                
                source
                    .AppendLine(";")
                    .DecrementIndentation()
                    .AppendLine("}")
                    .DecrementIndentation()
                    .AppendLine("}");
            }

            source
                .DecrementIndentation()
                .AppendLine("}");

            context.AddSource(
                $"{bitField.Name}.g.cs",
                source.ToString());
        }

        private static string CreateMask(int length)
        {
            return length == 32 ? "0xFFFFFFFF" : $"0x{((1u << length) - 1):X}";
        }
    }
}