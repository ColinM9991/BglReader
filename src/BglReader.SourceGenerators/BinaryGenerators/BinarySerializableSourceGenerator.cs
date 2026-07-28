using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.CodeAnalysis;

namespace BglReader.SourceGenerators.BinaryGenerators;

[Generator]
public sealed class BinarySerializableSourceGenerator : IIncrementalGenerator
{
    private static readonly IReadOnlyDictionary<SpecialType, PrimitiveRead> PrimitiveReaders =
        new Dictionary<SpecialType, PrimitiveRead>
        {
            [SpecialType.System_Boolean] = new(SpecialType.System_Boolean),
            [SpecialType.System_Byte] = new(SpecialType.System_Byte),
            [SpecialType.System_Int16] = new(SpecialType.System_Int16),
            [SpecialType.System_UInt16] = new(SpecialType.System_UInt16),
            [SpecialType.System_Int32] = new(SpecialType.System_Int32),
            [SpecialType.System_UInt32] = new(SpecialType.System_UInt32),
            [SpecialType.System_Single] = new(SpecialType.System_Single),
            [SpecialType.System_Double] = new(SpecialType.System_Single),
        };
    
    private static Func<AttributeData, bool> IsBinaryAttribute() => x =>
        x.AttributeClass?.ToDisplayString() == "BglReader.Attributes.BinaryAttributes.BinaryAttribute";
    
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var classes = context.SyntaxProvider.ForAttributeWithMetadataName(
            "BglReader.Attributes.BinaryAttributes.BinarySerializableAttribute",
            static (_, _) => true,
            TransformModel);

        context.RegisterSourceOutput(classes, Execute);
    }

    private static BinaryClass TransformModel(GeneratorAttributeSyntaxContext ctx,
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
        
        return new BinaryClass(
            typeSymbol.Name,
            typeSymbol.ContainingNamespace.ToDisplayString(),
            typeSymbol.BaseType is not null && typeSymbol.BaseType.SpecialType != SpecialType.System_Object,
            properties);
    }

    private static BinaryProperty BuildProperty(
        IPropertySymbol property)
    {
        return new BinaryProperty(
            property.Name,
            GetOrder(property),
            BuildInstruction(property));
    }

    private static ReadInstruction BuildInstruction(IPropertySymbol property)
    {
        var instruction = BuildCoreInstruction(property);

        if (TryGetCondition(property, out var condition))
        {
            instruction = new ConditionalRead(
                condition,
                instruction);
        }

        return instruction;
    }

    private static ReadInstruction BuildCoreInstruction(IPropertySymbol property)
    {
        if (TryGetPrimitive(property, out var primitive))
            return primitive;

        if (TryGetBitField(property, out var bitField))
            return bitField;

        if (TryGetBinaryReader(property, out var binaryReader))
            return binaryReader;
        
        return new NestedObjectRead(
            property.Type.ToDisplayString());
    }

    private static bool TryGetCondition(IPropertySymbol property, out string propertyName)
    {
        var conditionAttribute = property.GetAttributes().FirstOrDefault(x => x.AttributeClass?.Name == "BinaryConditionAttribute");
        if (conditionAttribute is null)
        {
            propertyName = null;
            return false;
        }

        var conditionProperty = (string)conditionAttribute.ConstructorArguments[0]!.Value!;
        propertyName = conditionProperty;
        return true;
    }
    
    private static bool TryGetBitField(IPropertySymbol property, out ReadInstruction instruction)
    {
        var bitField = property.Type.GetAttributes().FirstOrDefault(x => x.AttributeClass?.ToDisplayString() == "BglReader.Attributes.BitFieldAttribute");
        if (bitField is null)
        {
            instruction = null;
            return false;
        }

        var bitFieldType = (INamedTypeSymbol)bitField.ConstructorArguments[0]!.Value!;
        
        instruction = new BitFieldRead(bitFieldType.Name, bitFieldType.SpecialType);
        return true;
    }
    
    private static bool TryGetPrimitive(IPropertySymbol property, out ReadInstruction instruction)
    {
        if (PrimitiveReaders.TryGetValue(property.Type.SpecialType, out var primitiveRead))
        {
            instruction = primitiveRead;
            return true;
        }

        instruction = null;
        return false;
    }

    private static bool TryGetBinaryReader(IPropertySymbol property, out ReadInstruction instruction)
    {
        var binaryReaderAttribute = property.GetAttributes().FirstOrDefault(x => x.AttributeClass?.Name == "BinaryReaderAttribute");
        if (binaryReaderAttribute is null)
        {
            instruction = null;
            return false;
        }

        var readerType = (INamedTypeSymbol)binaryReaderAttribute.ConstructorArguments[0]!.Value!;
        instruction = new BinaryReaderRead(readerType.Name);
        return true;
    }

    private static int GetOrder(IPropertySymbol property)
    {
        var binaryAttribute =
            property.GetAttributes().FirstOrDefault(IsBinaryAttribute());

        return binaryAttribute != null ? (int)binaryAttribute.ConstructorArguments[0].Value! : 0;
    }

    private void Execute(SourceProductionContext ctx, BinaryClass record)
    {
        var sb = new IndentingStringBuilder();

        ctx.AddSource($"{record.Name}.g.cs", sb.ToString());
    }
}

public sealed record BinaryClass(
    string Name,
    string Namespace,
    bool IsInheriting,
    IReadOnlyList<BinaryProperty> Properties);

public sealed record BinaryProperty(
    string Name,
    int Order,
    ReadInstruction Instruction);

public abstract record ReadInstruction {}

public sealed record PrimitiveRead(SpecialType SpecialType) : ReadInstruction;

public sealed record BitFieldRead(
    string TypeName,
    SpecialType StorageType)
    : ReadInstruction;

public sealed record NestedObjectRead(string TypeName) : ReadInstruction;

public sealed record BinaryReaderRead(string ReaderType) : ReadInstruction;

public sealed record ConditionalRead(string ConditionProperty, ReadInstruction Instruction) : ReadInstruction;