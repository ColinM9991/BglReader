using System;
using System.Linq;
using BglReader.SourceGenerators.BinaryGenerators.Instructions.Decorated;
using BglReader.SourceGenerators.BinaryGenerators.Instructions.Primitive;
using Microsoft.CodeAnalysis;

namespace BglReader.SourceGenerators.BinaryGenerators.Instructions;

internal static class InstructionFactory
{
    private static readonly Func<IPropertySymbol, ITypeSymbol, ReadInstruction>[] Factories =
    [
        TryCreateConsumingRead,
        TryCreateBinaryReader,
        TryCreateEnumRead,
        TryCreatePrimitive,
        TryCreateBitField,
        TryCreatePolymorphicCollectionRead,
        TryCreateNestedObject
    ];

    internal static ReadInstruction Create(IPropertySymbol property)
    {
        var propertyType = property.Type.GetUnderlyingType();
        var instruction = Factories
            .Select(factory => factory(property, propertyType))
            .First(x => x is not null)!;

        if (TryGetCollection(property, out var collectionMetadata))
        {
            instruction = new CollectionRead(collectionMetadata.CountProperty, instruction as ValueReadInstruction);
        }

        if (TryGetCondition(property, out var condition))
        {
            instruction = new ConditionalRead(condition, instruction);
        }

        return instruction;
    }

    private static bool TryGetCollection(IPropertySymbol property, out CollectionMetadata collectionMetadata)
    {
        var attribute = property.GetAttribute("BinaryCollectionAttribute");
        if (attribute is null)
        {
            collectionMetadata = null;
            return false;
        }

        var countProperty = attribute.ConstructorArguments[0].Value!.ToString();

        collectionMetadata = new CollectionMetadata(countProperty);
        return true;
    }

    private static bool TryGetCondition(IPropertySymbol property, out Condition condition)
    {
        var conditionAttribute = property.GetAttribute("BinaryConditionAttribute");
        if (conditionAttribute is null)
        {
            condition = null;
            return false;
        }

        var conditionProperty = (string)conditionAttribute.ConstructorArguments[0]!.Value!;
        var comparer = (BinaryComparison)conditionAttribute.ConstructorArguments[1]!.Value!;
        var value = conditionAttribute.ConstructorArguments[2]!.Value!;
        var type = conditionAttribute.AttributeClass!.TypeArguments[0];

        condition = new Condition(type.GetUnderlyingType().ToDisplayString(), conditionProperty, comparer, value);
        return true;
    }

    private static ReadInstruction TryCreatePolymorphicCollectionRead(IPropertySymbol property, ITypeSymbol propertyType)
    {
        var attribute = property.GetAttribute("BinaryPolymorphicCollectionAttribute");
        if (attribute is null)
        {
            return null;
        }

        return new PolymorphicCollectionRead(attribute.ConstructorArguments[0].Value!.ToString(),
            attribute.ConstructorArguments[1].Value!.ToString());
    }

    private static ValueReadInstruction TryCreateConsumingRead(
        IPropertySymbol property,
        ITypeSymbol propertyType)
    {
        var consume = property.GetAttribute("BinaryConsumeAttribute");
        var fixedString = property.GetAttribute("BinaryStringAttribute");
        var nullTerminated =
            property.GetAttribute("BinaryNullTerminatedStringAttribute");

        var attributes = new[] { consume, fixedString, nullTerminated }
            .Where(attribute => attribute is not null)
            .ToArray();

        switch (attributes.Length)
        {
            case 0:
                return null;
            case > 1:
                throw new InvalidOperationException(
                    $"Property '{property.Name}' has conflicting binary read attributes.");
        }

        var attribute = attributes[0]!;

        return attribute.AttributeClass!.Name switch
        {
            "BinaryConsumeAttribute" =>
                new ByteCountRead(ParseConsumeLength(attribute)),

            "BinaryStringAttribute" =>
                new FixedByteStringRead(ParseConsumeLength(attribute)),

            "BinaryNullTerminatedStringAttribute" =>
                new NullTerminatedStringRead(
                    (int)attribute.ConstructorArguments[0].Value!),

            _ => throw new InvalidOperationException(
                $"Unsupported binary read attribute '{attribute.AttributeClass.Name}'.")
        };

        static ConsumeLength ParseConsumeLength(AttributeData attribute)
        {
            var value = attribute.ConstructorArguments[0].Value;

            return value switch
            {
                int count => new ConstantConsumeLength(count),
                string propertyName => new ReferencedConsumeLength(propertyName),
                _ => throw new InvalidOperationException(
                    $"Invalid byte-count specification: {value}")
            };
        }
    }

    private static ValueReadInstruction TryCreateEnumRead(IPropertySymbol property, ITypeSymbol propertyType)
    {
        if (propertyType.TypeKind != TypeKind.Enum)
        {
            return null;
        }

        var enumType = (INamedTypeSymbol)propertyType;
        return new EnumRead(propertyType.ToDisplayString(), enumType.EnumUnderlyingType!.SpecialType);
    }

    private static ValueReadInstruction TryCreateBitField(IPropertySymbol property, ITypeSymbol propertyType)
    {
        var bitField = propertyType.GetAttributes().FirstOrDefault(x =>
            x.AttributeClass?.ToDisplayString() == "BglReader.Attributes.BitFieldAttribute");
        if (bitField is null)
        {
            return null;
        }

        var bitFieldType = (INamedTypeSymbol)bitField.ConstructorArguments[0]!.Value!;
        return new BitFieldRead(propertyType.ToDisplayString(), bitFieldType.SpecialType);
    }

    private static ValueReadInstruction TryCreatePrimitive(IPropertySymbol property, ITypeSymbol propertyType)
    {
        return PrimitiveMap.Types.TryGetValue(propertyType.SpecialType, out var primitiveRead)
            ? primitiveRead
            : null;
    }

    private static ValueReadInstruction TryCreateBinaryReader(IPropertySymbol property, ITypeSymbol propertyType)
    {
        var binaryReaderAttribute = property.GetAttributes()
            .FirstOrDefault(x => x.AttributeClass?.Name == "BinaryReaderAttribute");
        if (binaryReaderAttribute is null)
        {
            return null;
        }

        var readerType = (INamedTypeSymbol)binaryReaderAttribute.ConstructorArguments[0]!.Value!;
        var readerInterface = readerType.Interfaces[0].Name;
        return new BinaryReaderRead(readerType.Name, readerInterface);
    }

    private static ValueReadInstruction TryCreateNestedObject(IPropertySymbol property, ITypeSymbol propertyType) =>
        new NestedObjectRead(
            propertyType.ToDisplayString());
}