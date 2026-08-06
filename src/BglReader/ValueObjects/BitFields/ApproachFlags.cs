using BglReader.Airport.Subsections.Approach;
using BglReader.Airport.Subsections.RunwayDetails;

namespace BglReader.ValueObjects.BitFields;

[BitField(typeof(byte))]
public partial class ApproachFlags
{
    [Bits(0, 4)]
    public partial ApproachType Type { get; }
    
    [Bits(4, 3)]
    public partial RunwayDesignator RunwayDesignator { get; }
    
    [Bits(7)]
    public partial bool HasGpsOverlay { get; }
}