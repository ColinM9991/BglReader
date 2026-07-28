using BglReader.Airport.Subsections.Types;
using BglReader.Attributes;
using BglReader.Types;

namespace BglReader.ValueObjects.BitFields;

[BitField(typeof(uint))]
public partial class FixFlags
{
    [Bits(0, 4)]
    public partial FixType Type { get; }
    
    [Bits(5, 27)]
    public partial IcaoIdentifier Identifier { get; }
}