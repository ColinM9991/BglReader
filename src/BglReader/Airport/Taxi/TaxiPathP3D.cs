using BglReader.ValueObjects;

namespace BglReader.Airport.Taxi;

public class TaxiPathP3D : TaxiPath
{
    public TaxiPathP3D(BglBinaryReader reader) : base(reader)
    {
        MaterialSet = new Guid(reader.ReadBytes(16));
        TerrainFlags = new TerrainFlags(reader.ReadByte());
        
        /* TODO
         * Byte 1: Unknown
         * Byte 2: Repeats Runway/Taxi Name Index
         * Byte 3: Unknown
         */
        _ = reader.ReadBytes(3); 
    }
    
    public Guid? MaterialSet { get; }
    
    public TerrainFlags TerrainFlags { get; }
}