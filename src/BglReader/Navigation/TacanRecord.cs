using BglReader.Generic;
using BglReader.Types;
using BglReader.ValueObjects.BitFields;

namespace BglReader.Navigation;

[BinarySerializable]
public partial class TacanRecord : BglRecord
{
    [Binary(1)]
    [BinaryReader(typeof(ThreeDimensionalCoordinateReader))]
    public Coordinate Coordinates { get; }
    
    [Binary(2)]
    public uint Channel { get; }
    
    [Binary(3)]
    public TacanFlags Flags { get; }
    
    [Binary(4)]
    public float Range { get; }
    
    [Binary(5)]
    [BinaryReader(typeof(MagneticVariationReader))]
    public MagneticVariation MagneticVariation { get; }
    
    [Binary(6)]
    [BinaryReader(typeof(ShiftedIcaoIdentifierReader))]
    public IcaoIdentifier Identifier { get; }
    
    [Binary(7)]
    public RegionFlags RegionFlags { get; }
    
    [Binary(8)]
    [BinaryPolymorphicCollection(typeof(NavigationDataFactory), typeof(NavigationDataType))]
    public ICollection<BglRecord> SubRecords { get; } = new List<BglRecord>();
}