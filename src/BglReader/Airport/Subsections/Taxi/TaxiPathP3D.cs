using BglReader.ValueObjects;

namespace BglReader.Airport.Subsections.Taxi;

public class TaxiPathP3D : TaxiPath
{
    public TaxiPathP3D(BglBinaryReader reader) : base(reader)
    {
        MaterialSet = new Guid(reader.ReadBytes(16));
        TerrainFlags = new TerrainFlags(reader.ReadByte());
        LightEdgeFixtureFlags = new LightEdgeFixtureFlags(reader.ReadByte());
        
        /* TODO
         * Byte 1: Repeats Runway/Taxi Name Index
         * Byte 2: Unknown
         */
        _ = reader.ReadBytes(2); 
    }
    
    public Guid? MaterialSet { get; }
    
    public TerrainFlags TerrainFlags { get; }
    
    /// <summary>
    /// This is a P3D V6 struct.
    /// </summary>
    public LightEdgeFixtureFlags LightEdgeFixtureFlags { get; }
}