using BglReader.Airport.Subsections.Types;
using BglReader.Generic;
using BglReader.Types;

namespace BglReader.Airport.Subsections.RunwayDetails;

public class AirportRunwayStartRecord : BglRecord
{
    public AirportRunwayStartRecord(ushort id, BglBinaryReader reader) : base(id, reader)
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