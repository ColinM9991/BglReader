using BglReader.Attributes;

namespace BglReader.ValueObjects;

[BitField(typeof(byte))]
public partial class ApronFlags
{
    [Bits(0)]
    public partial bool DrawSurface { get; }
    
    [Bits(1)]
    public partial bool DrawDetail { get; }
}