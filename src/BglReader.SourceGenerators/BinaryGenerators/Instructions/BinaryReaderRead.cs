namespace BglReader.SourceGenerators.BinaryGenerators.Instructions;

public sealed record BinaryReaderRead(string ReaderType) : ReadInstruction
{
    public override void Emit(string propertyName, IndentingStringBuilder sb)
    {
        sb.AppendLine($"{propertyName} = new {ReaderType}().Read(Id, reader);");
    }
}