using BglReader.Attributes;
using BglReader.Navigation;

namespace BglReader.ValueObjects;

[BitField(typeof(byte))]
public partial class TacanFlags
{
    [Bits(0)]
    public partial TacanBand Band { get; }
    
    [Bits(1)]
    public partial bool IsNotDmeOnly { get; }
}