using BglReader.Attributes;

namespace BglReader.ValueObjects;

[BitField(typeof(uint))]
public partial class WaypointSegmentRegionFlags
{
    [Bits(0, 11)]
    public partial IcaoIdentifier Region { get; }
    
    [Bits(11, 21)]
    public partial uint AirportId { get; }
}