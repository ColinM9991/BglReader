using BglReader.Types;
using BglReader.ValueObjects.BitFields;

namespace BglReader.Navigation;

[BinarySerializable]
public readonly partial struct WaypointSegment
{
    [Binary(1)]
    public WaypointSegmentFlags Flags { get; }

    [Binary(2)]
    public WaypointSegmentRegionFlags RegionFlags { get; }

    [Binary(3)]
    public float AltitudeMinimum { get; }
}