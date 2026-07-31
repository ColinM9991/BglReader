using Microsoft.CodeAnalysis;

namespace BglReader.SourceGenerators.BinaryGenerators.Instructions;

internal sealed record EnumRead(string EnumType, SpecialType UnderlyingType) : ReadInstruction
{
    public override void Emit(string propertyName, IndentingStringBuilder sb)
    {
        sb.AppendLine($"{propertyName} = ({EnumType}){PrimitiveMap.Readers[UnderlyingType]};");
    }
}