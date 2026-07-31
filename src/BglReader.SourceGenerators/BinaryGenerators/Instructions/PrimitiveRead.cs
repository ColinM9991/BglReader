using Microsoft.CodeAnalysis;

namespace BglReader.SourceGenerators.BinaryGenerators.Instructions;

internal sealed record PrimitiveRead(SpecialType SpecialType) : ReadInstruction
{
    public override void Emit(string propertyName, IndentingStringBuilder sb)
    {
        sb.AppendLine($"{propertyName} = {PrimitiveMap.Readers[SpecialType]};");
    }
}