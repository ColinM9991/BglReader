using BglReader.Generic;

namespace BglReader.Airport.Subsections.Approach;

[BinarySerializable]
public partial class AirportLegBaseRecord : BglRecord
{
    public AirportLegBaseRecord(BglBinaryReader reader) : this(reader.ReadUInt16(), reader)
    {
    }

    [Binary(0)] public ushort NumberOfLegs { get; }

    [Binary(1)]
    [BinaryCollection(nameof(NumberOfLegs))]
    public ICollection<ApproachLeg> Legs { get; } = [];
}