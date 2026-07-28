using BglReader.Generic;
using BglReader.ValueObjects.BitFields;

namespace BglReader.Airport.Subsections.RunwayDetails;

public class AirportApproachLightsSubRecord : BglRecord
{
    public AirportApproachLightsSubRecord(ushort id, BglBinaryReader reader) : base(id, reader)
    {
        Flags = new ApproachLightsFlags(reader.ReadByte());
        NumberOfStrobes = reader.ReadByte();
    }

    public ApproachLightsFlags Flags { get; }

    public byte NumberOfStrobes { get; }
}