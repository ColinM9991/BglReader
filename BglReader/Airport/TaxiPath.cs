namespace BglReader.Airport;

// TODO Flags
public class TaxiPath
{
    public TaxiPath(
        BinaryReader reader)
    {
        StartIndex = reader.ReadUInt16();
        PathFlags = reader.ReadUInt16();
        TypeFlags = reader.ReadByte();
        RunwayTaxiFlags = reader.ReadByte();
        Bitfield = reader.ReadByte();
        Surface = reader.ReadByte();
        Width = reader.ReadSingle();
        WeightLimit = reader.ReadSingle();

        _ = reader.ReadBytes(4);
    }

    public ushort StartIndex { get; }
    
    public ushort PathFlags { get; }
    
    public byte TypeFlags { get; }
    
    public byte RunwayTaxiFlags { get; }
    
    public byte Bitfield { get; }
    
    public byte Surface { get; }
    
    public float Width { get; }
    
    public float WeightLimit { get; }
}

public class TaxiPathP3D : TaxiPath
{
    public TaxiPathP3D(BinaryReader reader) : base(reader)
    {
        Material = new Guid(reader.ReadBytes(16));

        _ = reader.ReadBytes(4);
    }
    
    public Guid Material { get; }
}