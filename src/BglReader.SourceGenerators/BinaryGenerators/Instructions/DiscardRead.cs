namespace BglReader.SourceGenerators.BinaryGenerators.Instructions;

internal sealed record DiscardRead(int NumberOfBytes) : ValueReadInstruction
{
    internal override string EmitValue() => $"reader.ReadBytes({NumberOfBytes})";
}