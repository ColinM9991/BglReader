using BglReader.Attributes;
using BglReader.Generic;

namespace BglReader.Airport;

public class AirportRunwayStartRecord : BglRecord
{
    public AirportRunwayStartRecord(BglBinaryReader reader) : base(reader)
    {
        RunwayNumber = reader.ReadByte();
        Flags = new RunwayStartFlags(reader.ReadByte());
        Coordinates = reader.ReadCoordinates();
        Heading = reader.ReadSingle();
    }

    public byte RunwayNumber { get; }

    public RunwayStartFlags Flags { get; }

    public Coordinate Coordinates { get; }

    public float Heading { get; }
}

[BitField(typeof(byte))]
public partial class RunwayStartFlags
{
    [Bits(0, 3)]
    public partial RunwayDesignator Designator { get; }
    
    [Bits(4, 3)]
    public partial StartType StartType { get; }
}