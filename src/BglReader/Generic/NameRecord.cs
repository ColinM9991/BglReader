using BglReader.Navigation;

namespace BglReader.Generic;

public class NameRecord : BglRecord
{
    public NameRecord(
        ushort id,
        BglBinaryReader reader) : base(id, reader)
    {
        Name = reader.ReadString((int)GetRemainingBytes());
    }

    public string Name { get; }
}