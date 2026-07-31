namespace BglReader.SourceGenerators.BinaryGenerators.Instructions;

internal abstract record ValueReadInstruction : ReadInstruction
{
    internal abstract string EmitValue();
    
    public override void Emit(string propertyName, IndentingStringBuilder sb)
    {
        sb.AppendLine(
            $"{propertyName} = {EmitValue()};");
    }
}