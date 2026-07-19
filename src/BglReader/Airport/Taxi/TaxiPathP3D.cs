using BglReader.ValueObjects;

namespace BglReader.Airport.Taxi;

public class TaxiPathP3D : TaxiPath
{
    public TaxiPathP3D(BglBinaryReader reader) : base(reader)
    {
        Material = new Guid(reader.ReadBytes(16));
        TerrainFlags = new TerrainFlags(reader.ReadByte());
        
        /*
         * Byte 1: Unknown
         * Byte 2: Repeats Runway/Taxi Name Index
         * Byte 3: Unknown
         */
        _ = reader.ReadBytes(3); 
    }
    
    public Guid Material { get; }
    
    public TerrainFlags TerrainFlags { get; }
}