using BglReader.ValueObjects;

namespace BglReader.Airport;

public readonly struct ApproachLeg
{
    public ApproachLeg(
        BglBinaryReader reader)
    {
        Id = reader.ReadByte();
        AltitudeDescriptor = reader.ReadByte();
        Flags = new ApproachLegFlags(reader.ReadUInt16());
        FixFlags = new FixFlags(reader.ReadUInt32());
        IcaoFlags = new RegionIdentifierFlags(reader.ReadUInt32());
        RecommendedIdentFlags = new FixFlags(reader.ReadUInt32());
        RecommendedAirportFlags = new RegionIdentifierFlags(reader.ReadUInt32());
        Theta = reader.ReadSingle();
        Rho = reader.ReadSingle();
        Course = reader.ReadSingle();
        DistanceTime = reader.ReadSingle();
        Altitude1 = reader.ReadSingle();
        Altitude2 = reader.ReadSingle();
    }

    public byte Id { get; }

    public byte AltitudeDescriptor { get; }

    public ApproachLegFlags Flags { get; }

    public FixFlags FixFlags { get; }

    public RegionIdentifierFlags IcaoFlags { get; }

    public FixFlags RecommendedIdentFlags { get; }

    public RegionIdentifierFlags RecommendedAirportFlags { get; }

    public float Theta { get; }

    public float Rho { get; }

    public float Course { get; }

    public float DistanceTime { get; }

    public float Altitude1 { get; }

    public float Altitude2 { get; }
}