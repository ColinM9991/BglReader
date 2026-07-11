using BglReader.Airport;
using BglReader.Attributes;

namespace BglReader.ValueObjects;

[BitField(typeof(byte))]
public partial class ApproachFlags
{
    [Bits(0, 4)]
    public partial ApproachType Type { get; }
    
    [Bits(4, 3)]
    public partial int RunwayDesignator { get; }
    
    [Bits(7)]
    public partial bool HasGpsOverlay { get; }
}