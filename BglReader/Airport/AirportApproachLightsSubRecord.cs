using BglReader.Generic;

namespace BglReader.Airport;

public class AirportApproachLightsSubRecord : BglRecord
{
    public AirportApproachLightsSubRecord(BinaryReader reader) : base(reader)
    {
        Details = reader.ReadByte(); // TODO Flags
        NumberOfStrobes = reader.ReadByte();
    }

    public byte Details { get; }

    public byte NumberOfStrobes { get; }
}