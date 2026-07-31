using System;

namespace BglReader.SourceGenerators.BinaryGenerators.Instructions;

internal sealed record ConditionalRead(Condition Condition, ReadInstruction Instruction) : ReadInstruction
{
    public override void Emit(string propertyName, IndentingStringBuilder sb)
    {
        sb.AppendLine($"if ({Condition})")
            .AppendLine("{")
            .IncrementIndentation();
        
        Instruction.Emit(propertyName, sb);

        sb.DecrementIndentation()
            .AppendLine("}");
    }
}

internal sealed record Condition(string PropertyType, string Property, BinaryComparison Comparer, object Value)
{
    private string GetComparisonSymbol() => Comparer switch
    {
        BinaryComparison.Equal => "==",
        BinaryComparison.NotEqual => "!=",
        BinaryComparison.GreaterThan => ">",
        BinaryComparison.GreaterThanOrEqual => ">=",
        BinaryComparison.LessThan => "<",
        BinaryComparison.LessThanOrEqual => "<=",
        _ => throw new ArgumentOutOfRangeException(nameof(Comparer), Comparer, null)
    };

    public override string ToString() => $"{Property} {GetComparisonSymbol()} ({PropertyType}){Value}";
}