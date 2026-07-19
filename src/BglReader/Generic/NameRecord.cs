using System.Text;

namespace BglReader.Generic;

public class NameRecord : BglRecord
{
    public NameRecord(
        BglBinaryReader reader,
        bool shouldRewindStream = true) : base(reader, shouldRewindStream)
    {
        Name = reader.ReadString((int)GetRemainingBytes());
    }

    public string Name { get; }
}