namespace BglReader.Navigation;

public struct WaypointSegment
{
    public WaypointSegment(BinaryReader reader)
    {
        var waypointFlags = reader.ReadByte();

        Type = (WaypointSegmentType)(waypointFlags & 0x7);
        Identifier = IcaoIdentifier.Parse((uint)(waypointFlags >> 5) & 0x7FFFFFF);

        var regionFlags = reader.ReadUInt32();
        
        Region = IcaoIdentifier.Parse(regionFlags & 0x7FF);
        AirportId = (regionFlags >> 11) & 0x1FFFFF;

        AltitudeMinimum = reader.ReadSingle();
    }

    public WaypointSegmentType Type { get; }

    public IcaoIdentifier Identifier { get; }

    public IcaoIdentifier Region { get; }

    public uint AirportId { get; }

    public float AltitudeMinimum { get; }
}