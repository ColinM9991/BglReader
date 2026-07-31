using System;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace BglReader.SourceGenerators.BinaryGenerators.Instructions;

public class InstructionFactory
{
    private static readonly Func<IPropertySymbol, ReadInstruction>[] Factories =
    [
        TryCreateEnumRead,
        TryCreatePrimitive,
        TryCreateBitField,
        TryCreateBinaryReader,
        TryCreateCollectionRead,
        TryCreatePolymorphicCollectionRead,
        TryCreateNestedObject
    ];

    private static ReadInstruction TryCreateCollectionRead(IPropertySymbol propertySymbol)
    {
        var attribute = GetAttributeByName(propertySymbol, "BinaryCollectionAttribute");
        if (attribute is null)
        {
            return null;
        }

        var countProperty = attribute.ConstructorArguments[0].Value!.ToString();
        var namedTypeSymbol = (INamedTypeSymbol)propertySymbol.Type;
        var underlyingType = namedTypeSymbol.TypeArguments[0].GetUnderlyingType();

        return new CollectionRead(countProperty, underlyingType);
    }

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

    private static bool TryGetCondition(IPropertySymbol property, out Condition condition)
    {
        var conditionAttribute = GetAttributeByName(property, "BinaryConditionAttribute");
        if (conditionAttribute is null)
        {
            condition = null;
            return false;
        }

        var conditionProperty = (string)conditionAttribute.ConstructorArguments[0]!.Value!;
        var comparer = (BinaryComparison)conditionAttribute.ConstructorArguments[1]!.Value!;
        var value = conditionAttribute.ConstructorArguments[2]!.Value!;
        var type = conditionAttribute.AttributeClass!.TypeArguments[0];

        condition = new Condition(type.GetUnderlyingType(), conditionProperty, comparer, value);
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

    private static ReadInstruction TryCreateEnumRead(IPropertySymbol property)
    {
        if (property.Type.TypeKind != TypeKind.Enum)
        {
            return null;
        }

        var enumType = (INamedTypeSymbol)property.Type;
        return new EnumRead(property.Type.GetUnderlyingType(), enumType.EnumUnderlyingType!.SpecialType);
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
        return new BitFieldRead(property.Type.GetUnderlyingType(), bitFieldType.SpecialType);
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
        var readerInterface = readerType.Interfaces[0].Name;
        return new BinaryReaderRead(readerType.Name, readerInterface);
    }

    private static ReadInstruction TryCreateNestedObject(IPropertySymbol property) =>
        new NestedObjectRead(
            property.Type.GetUnderlyingType());

    private static AttributeData GetAttributeByName(IPropertySymbol property, string attributeName)
        => property.GetAttributes().FirstOrDefault(x => x.AttributeClass?.Name == attributeName);
}

public static class PropertySymbolExtensions
{
    extension(ITypeSymbol typeSymbol)
    {
        public string GetUnderlyingType()
        {
            if (typeSymbol is not INamedTypeSymbol namedTypeSymbol)
            {
                return typeSymbol.ToDisplayString();
            }

            if (namedTypeSymbol.OriginalDefinition.SpecialType is SpecialType.System_Nullable_T &&
                namedTypeSymbol.TypeArguments[0] is var nullableTypeArgument)
            {
                return nullableTypeArgument.ToDisplayString();
            }

            if (namedTypeSymbol.TypeKind is TypeKind.Enum || namedTypeSymbol.SpecialType is SpecialType.System_Enum)
            {
                return namedTypeSymbol.ConstructedFrom.ToDisplayString();
            }

            return namedTypeSymbol.OriginalDefinition.ToDisplayString();
        }
    }
}