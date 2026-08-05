using BglReader.Airport.Subsections.Types;
using BglReader.Generic;
using BglReader.Types;
using BglReader.ValueObjects.BitFields;

namespace BglReader.Navigation;

[BinarySerializable]
public partial class IlsVorRecord : BglRecord
{
    [Binary(1)]
    public IlsVorType Type { get; }
    
    [Binary(2)]
    public IlsVorFlag Flags { get; }
    
    [Binary(3)]
    [BinaryReader(typeof(ThreeDimensionalCoordinateReader))]
    public Coordinate Coordinates { get; }
    
    [Binary(4)]
    [BinaryReader(typeof(FrequencyValueReader))]
    public Frequency Frequency { get; }
    
    [Binary(5)]
    public float Range { get; }
    
    [Binary(6)]
    [BinaryReader(typeof(MagneticVariationReader))]
    public MagneticVariation MagneticVariation { get; }
    
    [Binary(7)]
    [BinaryReader(typeof(ShiftedIcaoIdentifierReader))]
    public IcaoIdentifier Identifier { get; }
    
    [Binary(8)]
    public RegionIdentifierFlags RegionFlags { get; }

    [Binary(9)]
    [BinaryPolymorphicCollection(typeof(NavigationDataFactory), typeof(NavigationDataType))]
    public ICollection<BglRecord> SubRecords { get; } = new List<BglRecord>();
}