namespace BglReader.SourceGenerators.BinaryGenerators.Instructions;

internal sealed record NestedObjectRead(
    string TypeName
    ) : ReadInstruction
{
    public override void Emit(string propertyName, IndentingStringBuilder sb)
    {
        sb.AppendLine($"{propertyName} = new {TypeName}(reader);");
    }
}