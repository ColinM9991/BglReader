using BglReader.Airport;
using BglReader.Attributes;

namespace BglReader.ValueObjects;

[BitField(typeof(ushort))]
public partial class TaxiPathFlags
{
    [Bits(0, 12)]
    public partial ushort EndIndex { get; }

    [Bits(12, 4)]
    public partial RunwayDesignator Designator { get; }
}