namespace BglReader.SourceGenerators.BinaryGenerators.Instructions;

internal sealed record NestedObjectRead(
    string TypeName) : ValueReadInstruction
{
    internal override string EmitValue() => $"new {TypeName}(reader)";
}