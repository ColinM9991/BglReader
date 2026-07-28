using BglReader.Airport.Subsections.RunwayDetails;
using BglReader.Attributes;

namespace BglReader.ValueObjects.BitFields;

[BitField(typeof(ushort))]
public partial class TaxiPathFlags
{
    [Bits(0, 12)]
    public partial ushort EndIndex { get; }

    [Bits(12, 4)]
    public partial RunwayDesignator Designator { get; }
}