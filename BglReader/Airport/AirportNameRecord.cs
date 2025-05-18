using System.Text;

namespace BglReader.Airport;

public class AirportNameRecord : BglRecord
{
    public AirportNameRecord(
        BinaryReader reader) : base(reader)
    {
        Name = Encoding.UTF8.GetString(reader.ReadBytes((int)Size - 6));
    }

    public string Name { get; set; }
}