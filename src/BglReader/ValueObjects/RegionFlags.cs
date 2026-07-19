using BglReader.Attributes;

namespace BglReader.ValueObjects;

[BitField(typeof(uint))]
public partial class RegionFlags
{
    [Bits(0, 11)]
    public partial IcaoIdentifier Region { get; }
}