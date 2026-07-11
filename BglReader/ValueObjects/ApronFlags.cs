using BglReader.Attributes;

namespace BglReader.ValueObjects;

[BitField(typeof(byte))]
public partial class ApronFlags
{
    [Bits(0)]
    public partial int DrawSurface { get; }
    
    [Bits(1)]
    public partial int DrawDetail { get; }
}