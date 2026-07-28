using BglReader.Attributes;
using BglReader.Types;

namespace BglReader.ValueObjects.BitFields;

[BitField(typeof(uint))]
public partial class RegionFlags
{
    [Bits(0, 11)]
    public partial IcaoIdentifier Region { get; }
}