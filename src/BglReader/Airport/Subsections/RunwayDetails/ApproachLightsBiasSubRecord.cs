using BglReader.Generic;
using BglReader.Types;
using BglReader.ValueObjects.BitFields;

namespace BglReader.Airport.Subsections.RunwayDetails;

public sealed class ApproachLightsBiasSubRecord : BglRecord
{
    public ApproachLightsBiasSubRecord(ushort id, BglBinaryReader reader) : base(id, reader)
    {
        Flags = new ApproachLightsFlags(reader.ReadByte());
        NumberOfStrobes = reader.ReadByte();
        Coordinate = reader.ReadCoordinates(false);
    }
    
    public ApproachLightsFlags Flags { get; }
    
    public int NumberOfStrobes { get; }
    
    public Coordinate Coordinate { get; }
}