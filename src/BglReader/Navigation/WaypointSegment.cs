using BglReader.ValueObjects;

namespace BglReader.Navigation;

public struct WaypointSegment
{
    private WaypointSegment(
        WaypointSegmentType type,
        IcaoIdentifier identifier,
        IcaoIdentifier region,
        uint airportId,
        float altitudeMinimum)
    {
        Type = type;
        Identifier = identifier;
        Region = region;
        AirportId = airportId;
        AltitudeMinimum = altitudeMinimum;
    }

    public WaypointSegmentType Type { get; }

    public IcaoIdentifier Identifier { get; }

    public IcaoIdentifier Region { get; }

    public uint AirportId { get; }

    public float AltitudeMinimum { get; }

    public static WaypointSegment? Parse(BglBinaryReader reader)
    {
        var waypointFlags = new WaypointSegmentFlags(reader.ReadUInt32());
        var regionFlags = new WaypointSegmentRegionFlags(reader.ReadUInt32());

        var altitudeMinimum = reader.ReadSingle();

        return waypointFlags.Type is WaypointSegmentType.Named or WaypointSegmentType.Ndb or WaypointSegmentType.Vor
            ? new WaypointSegment(waypointFlags.Type, waypointFlags.Identifier, regionFlags.Region, regionFlags.AirportId, altitudeMinimum)
            : null;
    }
}