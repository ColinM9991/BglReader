using BglReader.Generic;
using BglReader.Types;
using BglReader.ValueObjects.BitFields;

namespace BglReader.Airport.Subsections.RunwayDetails;

[BinarySerializable]
public sealed partial class ApproachLightsBiasSubRecord : BglRecord
{
    [Binary(1)]
    public ApproachLightsFlags Flags { get; }
    
    [Binary(2)]
    public byte NumberOfStrobes { get; }
    
    [Binary(3)]
    [BinaryReader(typeof(TwoDimensionalCoordinateReader))]
    public Coordinate Coordinate { get; }
}