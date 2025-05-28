using BglReader.Generic;

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

    public VasiType Type { get; }

    public float BiasX { get; }

    public float BiasZ { get; }

    public float Spacing { get; }

    public float Pitch { get; }
}