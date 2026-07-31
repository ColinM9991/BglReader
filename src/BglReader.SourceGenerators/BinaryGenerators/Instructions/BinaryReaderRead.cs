using System;

namespace BglReader.SourceGenerators.BinaryGenerators.Instructions;

internal sealed record BinaryReaderRead(string ReaderType, string Interface) : ReadInstruction
{
    public override void Emit(string propertyName, IndentingStringBuilder sb)
    {
        var parametersExpression = GetParameters();
        sb.AppendLine($"{propertyName} = new {ReaderType}().Read({parametersExpression});");
    }

    private string GetParameters() => Interface switch
    {
        "IBinaryRecordReader" => "Id, reader",
        "IBinaryValueReader" => "reader",
        _ => throw new ArgumentOutOfRangeException(nameof(Interface), Interface, null)
    };
}