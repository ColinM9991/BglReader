using BglReader.Attributes;

namespace BglReader.ValueObjects;

[BitField(typeof(byte))]
public partial class BoundaryFlags
{
    [Bits(0, 4)]
    public partial int MaximumAltitudeType { get; }
    
    [Bits(4, 4)]
    public partial int MinimumAltitudeType { get; }
}