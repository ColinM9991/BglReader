using BglReader.Generic;
using BglReader.ValueObjects;

namespace BglReader.Airport;

public sealed class ApproachLightsBiasSubRecord : BglRecord
{
    public ApproachLightsBiasSubRecord(BglBinaryReader reader) : base(reader)
    {
        Flags = new ApproachLightsFlags(reader.ReadByte());
        NumberOfStrobes = reader.ReadByte();
        Coordinate = reader.ReadCoordinates(false);
    }
    
    public ApproachLightsFlags Flags { get; }
    
    public int NumberOfStrobes { get; }
    
    public Coordinate Coordinate { get; }
}