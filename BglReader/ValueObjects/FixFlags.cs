using BglReader.Airport;
using BglReader.Attributes;

namespace BglReader.ValueObjects;

[BitField(typeof(uint))]
public partial class FixFlags
{
    [Bits(0, 4)]
    public partial FixType Type { get; }
    
    [Bits(5, 27)]
    public partial IcaoIdentifier Identifier { get; }
}