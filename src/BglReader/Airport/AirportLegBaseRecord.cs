using BglReader.Generic;

namespace BglReader.Airport;

public class AirportLegBaseRecord : BglRecord
{
    public AirportLegBaseRecord(
        BglBinaryReader reader, bool shouldRewindStream = true) : base(reader, shouldRewindStream)
    {
        NumberOfLegs = reader.ReadUInt16();
        Legs = Enumerable.Range(0, NumberOfLegs).Select(_ => new ApproachLeg(reader)).ToList();
    }

    public ushort NumberOfLegs { get; }

    public ICollection<ApproachLeg> Legs { get; }
}