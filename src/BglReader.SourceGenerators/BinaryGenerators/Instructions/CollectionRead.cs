namespace BglReader.SourceGenerators.BinaryGenerators.Instructions;

internal sealed record CollectionRead(string CountProperty, string TargetType) : ReadInstruction
{
    public override void Emit(string propertyName, IndentingStringBuilder sb)
    {
        sb.AppendLine(
            $"{propertyName} = System.Linq.Enumerable.Range(0, {CountProperty}).Select(_ => new {TargetType}(reader)).ToList();");
    }
}