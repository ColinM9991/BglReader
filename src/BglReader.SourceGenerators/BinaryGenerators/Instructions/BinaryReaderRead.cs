using System;

namespace BglReader.SourceGenerators.BinaryGenerators.Instructions;

internal sealed record BinaryReaderRead(string ReaderType, string Interface) : ValueReadInstruction
{
    internal override string EmitValue()
    {
        var parametersExpression = GetParameters();
        return $"new {ReaderType}().Read({parametersExpression})";
    }

    private string GetParameters() => Interface switch
    {
        "IBinaryRecordReader" => "new BglRecordContext(Id, this), reader",
        "IBinaryValueReader" => "reader",
        _ => throw new ArgumentOutOfRangeException(nameof(Interface), Interface, null)
    };
}