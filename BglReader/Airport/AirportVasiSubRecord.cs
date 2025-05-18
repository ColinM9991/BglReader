namespace BglReader.Airport;

public class AirportVasiSubRecord : BglRecord
{
    public AirportVasiSubRecord(BinaryReader reader) : base(reader)
    {
        Type = (VasiType)reader.ReadUInt16();
        BiasX = reader.ReadSingle();
        BiasZ = reader.ReadSingle();
        Spacing = reader.ReadSingle();
        Pitch = reader.ReadSingle();
    }

    public VasiType Type { get; set; }

    public float BiasX { get; set; }

    public float BiasZ { get; set; }

    public float Spacing { get; set; }

    public float Pitch { get; set; }
}