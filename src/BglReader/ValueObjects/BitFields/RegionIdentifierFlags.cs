using BglReader.Types;

namespace BglReader.ValueObjects.BitFields;

[BitField(typeof(uint))]
public partial class RegionIdentifierFlags : RegionFlags
{
    [Bits(11, 21)]
    public partial IcaoIdentifier Identifier { get; }
}