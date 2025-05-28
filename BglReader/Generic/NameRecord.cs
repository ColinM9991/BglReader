using System.Text;
using BglReader.Generic;

namespace BglReader;

public class NameRecord : BglRecord
{
    public NameRecord(
        BinaryReader reader,
        bool shouldRewindStream = true) : base(reader, shouldRewindStream)
    {
        Name = Encoding.UTF8.GetString(reader.ReadBytes((int)Size - HeaderSize));
    }

    public string Name { get; }
}