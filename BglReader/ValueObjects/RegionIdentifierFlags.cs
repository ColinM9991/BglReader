using BglReader.Attributes;

namespace BglReader.ValueObjects;

[BitField(typeof(uint))]
public partial class RegionIdentifierFlags : RegionFlags
{
    [Bits(11, 21)]
    public partial ShiftedIcaoIdentifier Identifier { get; }
}