using BglReader.Generic;

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

    public byte RunwayNumber { get; }

    public byte RunwayInfo { get; }

    public Coordinate Coordinates { get; }

    public float Heading { get; }
}