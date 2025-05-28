using BglReader.Generic;

namespace BglReader.Airport;

public class AirportLegBaseRecord : BglRecord
{
    public AirportLegBaseRecord(
        BinaryReader reader, bool shouldRewindStream = true) : base(reader, shouldRewindStream)
    {
        NumberOfLegs = reader.ReadUInt16();

        MapLegs(reader);
    }

    public ushort NumberOfLegs { get; }

    public ICollection<ApproachLeg> Legs { get; } = new List<ApproachLeg>();

    private void MapLegs(BinaryReader reader)
    {
        if (NumberOfLegs == 0) return;

        for (var i = 0; i < NumberOfLegs; i++)
        {
            Legs.Add(new ApproachLeg(reader));
        }
    }
}