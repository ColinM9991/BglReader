using BglReader.ValueObjects;

namespace BglReader.Airport;

public class TaxiPath
{
    public TaxiPath(
        BinaryReader reader)
    {
        StartIndex = reader.ReadUInt16();
        PathFlags = new TaxiPathFlags(reader.ReadUInt16());
        TypeFlags = new SurfacePointFlags(reader.ReadByte());
        TaxiNameIndex = reader.ReadByte();
        EdgeFlags = new SurfaceLineFlags(reader.ReadByte());
        Surface = (SurfaceType)reader.ReadByte();
        Width = reader.ReadSingle();
        WeightLimit = reader.ReadSingle();

        _ = reader.ReadBytes(4);
    }

    public ushort StartIndex { get; }
    
    public TaxiPathFlags PathFlags { get; }
    
    public SurfacePointFlags TypeFlags { get; }
    
    public byte TaxiNameIndex { get; }
    
    public SurfaceLineFlags EdgeFlags { get; }
    
    public SurfaceType Surface { get; }
    
    public float Width { get; }
    
    public float WeightLimit { get; }
}