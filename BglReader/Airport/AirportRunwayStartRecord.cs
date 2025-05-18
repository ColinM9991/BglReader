namespace BglReader.Airport;

public class AirportRunwayStartRecord : BglRecord
{
    public AirportRunwayStartRecord(BinaryReader reader) : base(reader)
    {
        RunwayNumber = reader.ReadByte();
        RunwayInfo = reader.ReadByte();
        Coordinates = new Coordinate(reader.ReadInt32(), reader.ReadInt32(), reader.ReadInt32());
        Heading = reader.ReadSingle();
    }

    public byte RunwayNumber { get; set; }

    public byte RunwayInfo { get; set; }

    public Coordinate Coordinates { get; set; }

    public float Heading { get; set; }
}