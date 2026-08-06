using System.Linq;
using Microsoft.CodeAnalysis;

namespace BglReader.SourceGenerators.BinaryGenerators.Instructions;

internal static class PropertySymbolExtensions
{
    extension(IPropertySymbol property)
    {
        internal AttributeData GetAttribute(string name) => property.GetAttributes().FirstOrDefault(a => a.AttributeClass?.Name == name);
    }
    
    extension(INamedTypeSymbol typeSymbol)
    {
        private bool IsCollectionType() => typeSymbol.ConstructedFrom.SpecialType is SpecialType.System_Array
            or SpecialType.System_Collections_Generic_IEnumerable_T
            or SpecialType.System_Collections_Generic_IReadOnlyCollection_T
            or SpecialType.System_Collections_Generic_ICollection_T
            or SpecialType.System_Collections_Generic_IReadOnlyList_T
            or SpecialType.System_Collections_Generic_IList_T;
    }

    extension(ITypeSymbol typeSymbol)
    {
        public ITypeSymbol GetUnderlyingType()
        {
            if (typeSymbol is IArrayTypeSymbol array)
                return array.ElementType;

            if (typeSymbol is not INamedTypeSymbol namedTypeSymbol)
                return typeSymbol;

            if (namedTypeSymbol.IsCollectionType())
                return namedTypeSymbol.TypeArguments[0].GetUnderlyingType();

            if (namedTypeSymbol.NullableAnnotation is NullableAnnotation.Annotated)
            {
                return namedTypeSymbol.TypeArguments.Length > 0
                    ? namedTypeSymbol.TypeArguments[0].GetUnderlyingType()
                    : namedTypeSymbol.ConstructedFrom.GetUnderlyingType();
            }

            return namedTypeSymbol;
        }
    }
}