using BglReader.ValueObjects;

namespace BglReader.Airport.Taxi;

public class TaxiPath
{
    public TaxiPath(
        BglBinaryReader reader)
    {
        StartIndex = reader.ReadUInt16();
        PathFlags = new TaxiPathFlags(reader.ReadUInt16());
        TypeFlags = new SurfacePointFlags(reader.ReadByte());
        PathValue = reader.ReadByte();
        EdgeFlags = new SurfaceLineFlags(reader.ReadByte());
        Surface = (SurfaceType)reader.ReadByte();
        Width = reader.ReadSingle();
        WeightLimit = reader.ReadInt32();

        _ = reader.ReadBytes(4); // TODO Unknown
    }

    public ushort StartIndex { get; }
    
    public TaxiPathFlags PathFlags { get; }
    
    public SurfacePointFlags TypeFlags { get; }
    
    /// <summary>
    /// Runway number if this is for a runway path. Otherwise it's the index to the taxi name.
    /// </summary>
    public byte PathValue { get; }
    
    public SurfaceLineFlags EdgeFlags { get; }
    
    public SurfaceType Surface { get; }
    
    public float Width { get; }
    
    public int WeightLimit { get; }
}