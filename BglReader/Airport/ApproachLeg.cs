namespace BglReader.Airport;

//TODO Flags
public readonly struct ApproachLeg
{
    public ApproachLeg(
        BinaryReader reader)
    {
        Id = reader.ReadByte();
        AltitudeDescriptor = reader.ReadByte();
        Flags = reader.ReadUInt16();
        FixFlags = reader.ReadUInt32();
        IcaoFlags = reader.ReadUInt32();
        RecommendedIdentFlags = reader.ReadUInt32();
        RecommendedAirportFlags = reader.ReadUInt32();
        Theta = reader.ReadSingle();
        Rho = reader.ReadSingle();
        Course = reader.ReadSingle();
        DistanceTime = reader.ReadSingle();
        Altitude1 = reader.ReadSingle();
        Altitude2 = reader.ReadSingle();
    }

    public byte Id { get; }

    public byte AltitudeDescriptor { get; }

    public ushort Flags { get; }

    public uint FixFlags { get; }

    public uint IcaoFlags { get; }

    public uint RecommendedIdentFlags { get; }

    public uint RecommendedAirportFlags { get; }

    public float Theta { get; }

    public float Rho { get; }

    public float Course { get; }

    public float DistanceTime { get; }

    public float Altitude1 { get; }

    public float Altitude2 { get; }
}