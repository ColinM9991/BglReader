using BglReader.Generic;

namespace BglReader.Airport.Subsections.Approach;

public class AirportLegBaseRecord : BglRecord
{
    public AirportLegBaseRecord(
        ushort id,
        BglBinaryReader reader) : base(id, reader)
    {
        NumberOfLegs = reader.ReadUInt16();
        Legs = Enumerable.Range(0, NumberOfLegs).Select(_ => new ApproachLeg(reader)).ToList();
    }

    public AirportLegBaseRecord(BglBinaryReader reader) : this(reader.ReadUInt16(), reader)
    {
    }

    public ushort NumberOfLegs { get; }

    public ICollection<ApproachLeg> Legs { get; }
}