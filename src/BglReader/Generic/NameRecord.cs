namespace BglReader.Generic;

[BinarySerializable]
public partial class NameRecord : BglRecord
{
    [Binary(1)]
    [BinaryString(nameof(RemainingBytes))]
    public string Name { get; }
}