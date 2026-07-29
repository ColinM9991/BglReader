using Microsoft.CodeAnalysis;

namespace BglReader.SourceGenerators.BinaryGenerators.Instructions;

public sealed record BitFieldRead(
    string TypeName,
    SpecialType StorageType)
    : ReadInstruction
{
    public override void Emit(string propertyName, IndentingStringBuilder sb)
    {
        sb.AppendLine($"{propertyName} = new {TypeName}({PrimitiveMap.Readers[StorageType]});");
    }
}