namespace BglReader.SourceGenerators.BinaryGenerators.Instructions.Primitive;

internal sealed record NestedObjectRead(
    string TypeName) : ValueReadInstruction
{
    internal override string EmitValue() => $"new {TypeName}(reader)";
}