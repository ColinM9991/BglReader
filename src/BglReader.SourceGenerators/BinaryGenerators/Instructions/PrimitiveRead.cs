using Microsoft.CodeAnalysis;

namespace BglReader.SourceGenerators.BinaryGenerators.Instructions;

internal sealed record PrimitiveRead(SpecialType SpecialType) : ValueReadInstruction
{
    internal override string EmitValue() => PrimitiveMap.Readers[SpecialType];
}