using BglReader.Airport.Subsections.Types;
using BglReader.Attributes.BinaryAttributes;
using BglReader.Generic;
using BglReader.Types;

namespace BglReader.Airport.Subsections.RunwayDetails;

[BinarySerializable]
public partial class AirportRunwayStartRecord : BglRecord
{
    [Binary(1)]
    public byte RunwayNumber { get; }

    [Binary(2)]
    public RunwayStartFlags Flags { get; }

    [Binary(3)]
    [BinaryReader(typeof(ThreeDimensionalCoordinateReader))]
    public Coordinate Coordinates { get; }

    [Binary(4)]
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