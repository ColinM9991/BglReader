using System.Text;

namespace BglReader;

public class NameRecord : BglRecord
{
    public NameRecord(
        BinaryReader reader,
        bool shouldRewind = true) : base(reader, shouldRewind)
    {
        Name = Encoding.UTF8.GetString(reader.ReadBytes((int)Size - HeaderSize));
    }

    public string Name { get; }
}