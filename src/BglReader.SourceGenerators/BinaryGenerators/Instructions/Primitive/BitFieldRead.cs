using Microsoft.CodeAnalysis;

namespace BglReader.SourceGenerators.BinaryGenerators.Instructions.Primitive;

internal sealed record BitFieldRead(
    string TypeName,
    SpecialType StorageType)
    : ValueReadInstruction
{
    internal override string EmitValue() => $"new {TypeName}({PrimitiveMap.Readers[StorageType]})";
}