using BglReader.Types;
using BglReader.ValueObjects.BitFields;

namespace BglReader.Navigation;

[BinarySerializable]
public partial class WaypointSegment
{
    [Binary(1)]
    public WaypointSegmentFlags Flags { get; }

    [Binary(2)]
    public WaypointSegmentRegionFlags RegionFlags { get; }

    [Binary(3)]
    public float AltitudeMinimum { get; }
}