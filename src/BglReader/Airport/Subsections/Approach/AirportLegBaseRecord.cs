using BglReader.Attributes.BinaryAttributes;
using BglReader.Generic;

namespace BglReader.Airport.Subsections.Approach;

[BinarySerializable]
public partial class AirportLegBaseRecord : BglRecord
{
    [Binary(0)]
    public ushort NumberOfLegs { get; }

    [Binary(1)]
    [BinaryCollection(nameof(NumberOfLegs))]
    public ICollection<ApproachLeg> Legs { get; } = [];
}