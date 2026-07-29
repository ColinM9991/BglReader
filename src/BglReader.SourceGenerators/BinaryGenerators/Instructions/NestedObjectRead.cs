namespace BglReader.SourceGenerators.BinaryGenerators.Instructions;

public sealed record NestedObjectRead(string TypeName) : ReadInstruction
{
    public override void Emit(string propertyName, IndentingStringBuilder sb)
    {
        sb.AppendLine($"{propertyName} = new {TypeName}(reader);");
    }
}