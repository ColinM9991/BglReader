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

    public static WaypointSegment? Parse(BinaryReader reader)
    {
        var waypointFlags = reader.ReadUInt32();

        var type = (WaypointSegmentType)(waypointFlags & 0x7);

        var identifier = IcaoIdentifier.Parse((uint)(waypointFlags >> 5) & 0x7FFFFFF);

        var regionFlags = reader.ReadUInt32();

        var region = IcaoIdentifier.Parse(regionFlags & 0x7FF);
        var airportId = (regionFlags >> 11) & 0x1FFFFF;

        var altitudeMinimum = reader.ReadSingle();

        return type is WaypointSegmentType.Named or WaypointSegmentType.Ndb or WaypointSegmentType.Vor
            ? new WaypointSegment(type, identifier, region, airportId, altitudeMinimum)
            : null;
    }
}