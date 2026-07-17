using System.Text;

namespace BglReader.Generic;

public class NameRecord : BglRecord
{
    public NameRecord(
        BinaryReader reader,
        bool shouldRewindStream = true) : base(reader, shouldRewindStream)
    {
        Name = Encoding.UTF8.GetString(Consume(reader));
    }

    public string Name { get; }
}