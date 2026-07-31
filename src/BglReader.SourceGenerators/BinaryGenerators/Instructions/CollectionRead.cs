namespace BglReader.SourceGenerators.BinaryGenerators.Instructions;

internal sealed record CollectionRead(string CountProperty, ValueReadInstruction ValueReadInstruction) : ReadInstruction
{
    public override void Emit(string propertyName, IndentingStringBuilder sb)
    {
        sb.AppendLine(
            $"{propertyName} = System.Linq.Enumerable.Range(0, {CountProperty}).Select(_ => {ValueReadInstruction.EmitValue()}).ToList();");
    }
}

internal sealed record CollectionMetadata(string CountProperty);