using BglReader.Generic;
using BglReader.ValueObjects;

namespace BglReader.Airport;

public class AirportApproachLightsSubRecord : BglRecord
{
    public AirportApproachLightsSubRecord(BinaryReader reader) : base(reader)
    {
        Flags = new ApproachLightsFlags(reader.ReadByte());
        NumberOfStrobes = reader.ReadByte();
    }

    public ApproachLightsFlags Flags { get; }

    public byte NumberOfStrobes { get; }
}