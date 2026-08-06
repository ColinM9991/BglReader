using BglReader.Generic;

namespace BglReader.Airport.Subsections.Approach;

[BinarySerializable]
public partial class AirportLegBaseRecord : BglRecord
{
    public AirportLegBaseRecord(BglBinaryReader reader) : this(reader.ReadUInt16(), reader)
    {
    }

    [Binary(1)]
    public ushort NumberOfLegs { get; }

    [Binary(2)]
    [BinaryCollection(nameof(NumberOfLegs))]
    public ICollection<ApproachLeg> Legs { get; } = [];
}