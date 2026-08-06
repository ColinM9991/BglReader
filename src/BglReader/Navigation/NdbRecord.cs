using BglReader.Airport.Subsections.Types;
using BglReader.Generic;
using BglReader.Types;
using BglReader.ValueObjects.BitFields;

namespace BglReader.Navigation;

[BinarySerializable]
public partial class NdbRecord : BglRecord
{
    [Binary(1)]
    public NdbType Type { get; }
    
    [Binary(2)]
    [BinaryReader(typeof(FrequencyValueReader))]
    public Frequency Frequency { get; }
    
    [Binary(3)]
    [BinaryReader(typeof(ThreeDimensionalCoordinateReader))]
    public Coordinate Coordinates { get; }
    
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

public enum NdbType : ushort
{
    CompassPoint = 0,
    MediumHoming = 1,
    Homing = 2,
    HighHoming = 3
}