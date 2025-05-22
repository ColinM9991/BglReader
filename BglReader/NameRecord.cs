using System.Text;

namespace BglReader;

public class NameRecord : BglRecord
{
    public NameRecord(
        BinaryReader reader) : base(reader)
    {
        Name = Encoding.UTF8.GetString(reader.ReadBytes((int)Size - 6));
    }

    public string Name { get; set; }
}