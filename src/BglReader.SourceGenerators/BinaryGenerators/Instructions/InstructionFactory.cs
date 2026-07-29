using System;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace BglReader.SourceGenerators.BinaryGenerators.Instructions;

public class InstructionFactory
{
    private static readonly Func<IPropertySymbol, ReadInstruction>[] Factories =
    [
        TryCreatePrimitive,
        TryCreateBitField,
        TryCreateBinaryReader,
        TryCreatePolymorphicCollectionRead,
        TryCreateNestedObject
    ];

    internal static ReadInstruction Create(IPropertySymbol property)
    {
        var instruction = Factories
            .Select(factory => factory(property))
            .First(x => x is not null)!;

        if (TryGetCondition(property, out var condition))
        {
            instruction = new ConditionalRead(condition, instruction);
        }

        return instruction;
    }

    private static bool TryGetCondition(IPropertySymbol property, out string propertyName)
    {
        var conditionAttribute = property.GetAttributes()
            .FirstOrDefault(x => x.AttributeClass?.Name == "BinaryConditionAttribute");
        if (conditionAttribute is null)
        {
            propertyName = null;
            return false;
        }

        var conditionProperty = (string)conditionAttribute.ConstructorArguments[0]!.Value!;
        propertyName = conditionProperty;
        return true;
    }

    private static ReadInstruction TryCreatePolymorphicCollectionRead(IPropertySymbol property)
    {
        var attribute = GetAttributeByName(property, "BinaryPolymorphicCollectionAttribute");
        if (attribute is null)
        {
            return null;
        }

        return new PolymorphicCollectionRead(attribute.ConstructorArguments[0].Value!.ToString(),
            attribute.ConstructorArguments[1].Value!.ToString());
    }
    
    private static ReadInstruction TryCreateBitField(IPropertySymbol property)
    {
        var bitField = property.Type.GetAttributes().FirstOrDefault(x =>
            x.AttributeClass?.ToDisplayString() == "BglReader.Attributes.BitFieldAttribute");
        if (bitField is null)
        {
            return null;
        }

        var bitFieldType = (INamedTypeSymbol)bitField.ConstructorArguments[0]!.Value!;
        return new BitFieldRead(property.Type.ToDisplayString(), bitFieldType.SpecialType);
        ;
    }

    private static ReadInstruction TryCreatePrimitive(IPropertySymbol property)
    {
        if (PrimitiveMap.Types.TryGetValue(property.Type.SpecialType, out var primitiveRead))
        {
            return primitiveRead;
        }

        return null;
    }

    private static ReadInstruction TryCreateBinaryReader(IPropertySymbol property)
    {
        var binaryReaderAttribute = property.GetAttributes()
            .FirstOrDefault(x => x.AttributeClass?.Name == "BinaryReaderAttribute");
        if (binaryReaderAttribute is null)
        {
            return null;
        }

        var readerType = (INamedTypeSymbol)binaryReaderAttribute.ConstructorArguments[0]!.Value!;
        return new BinaryReaderRead(readerType.Name);
    }

    private static ReadInstruction TryCreateNestedObject(IPropertySymbol property) => new NestedObjectRead(
        property.Type.ToDisplayString());
    
    private static AttributeData GetAttributeByName(IPropertySymbol property, string attributeName) 
        => property.GetAttributes().FirstOrDefault(x => x.AttributeClass?.Name == attributeName);
}