using Microsoft.CodeAnalysis;

namespace BglReader.SourceGenerators.BinaryGenerators.Instructions.Primitive;

internal sealed record PrimitiveRead(SpecialType SpecialType) : ValueReadInstruction
{
    internal override string EmitValue() => PrimitiveMap.Readers[SpecialType];
}