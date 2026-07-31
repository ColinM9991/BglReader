using Microsoft.CodeAnalysis;

namespace BglReader.SourceGenerators.BinaryGenerators.Instructions;

internal sealed record EnumRead(string EnumType, SpecialType UnderlyingType) : ValueReadInstruction
{
    internal override string EmitValue() => $"({EnumType}){PrimitiveMap.Readers[UnderlyingType]}";
}