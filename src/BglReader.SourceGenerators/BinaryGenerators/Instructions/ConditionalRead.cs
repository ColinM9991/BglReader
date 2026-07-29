namespace BglReader.SourceGenerators.BinaryGenerators.Instructions;

public sealed record ConditionalRead(string ConditionProperty, ReadInstruction Instruction) : ReadInstruction
{
    public override void Emit(string propertyName, IndentingStringBuilder sb)
    {
        sb.AppendLine($"if ({ConditionProperty} > 0)")
            .AppendLine("{")
            .IncrementIndentation();
        
        Instruction.Emit(propertyName, sb);

        sb.DecrementIndentation()
            .AppendLine("}");
    }
}