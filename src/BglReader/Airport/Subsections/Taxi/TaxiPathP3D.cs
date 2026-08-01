using BglReader.Airport.Subsections.Types;
using BglReader.Attributes.BinaryAttributes;
using BglReader.ValueObjects.BitFields;

namespace BglReader.Airport.Subsections.Taxi;

[BinarySerializable]
public partial class TaxiPath : ITaxiPath
{
    [Binary(1)]
    public ushort StartIndex { get; }
    
    [Binary(2)]
    public TaxiPathFlags PathFlags { get; }
    
    [Binary(3)]
    public SurfacePointFlags TypeFlags { get; }
    
    [Binary(4)]
    public byte PathValue { get; }
    
    [Binary(5)]
    public SurfaceLineFlags EdgeFlags { get; }
    
    [Binary(6)]
    public SurfaceType Surface { get; }
    
    [Binary(7)]
    public float Width { get; }
    
    [Binary(8)]
    public int WeightLimit { get; }
    
    [Binary(9)]
    [BinaryDiscard(4)]
    public byte[] Unknown { get; }
    
    [Binary(10)]
    [BinaryReader(typeof(GuidValueReader))]
    public Guid? MaterialSet { get; }
    
    [Binary(11)]
    public TerrainFlags TerrainFlags { get; }
    
    /// <summary>
    /// This is a P3D V6 struct.
    /// </summary>
    [Binary(12)]
    public LightEdgeFixtureFlags LightEdgeFixtureFlags { get; }
    
    /* TODO
     * Byte 1: Repeats Runway/Taxi Name Index
     * Byte 2: Unknown
     */
    [Binary(13)]
    [BinaryDiscard(2)]
    public byte[] Trailing { get; }
}