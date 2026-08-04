using BglReader.Generic;
using BglReader.Types;
using BglReader.ValueObjects.BitFields;

namespace BglReader.Airport;

[BinarySerializable]
public partial class AirportRecord : BglRecord
{
    public AirportType Type => (AirportType)Id;

    [Binary(1)]
    public byte NumberOfRunways { get; }

    [Binary(2)]
    public byte NumberOfCom { get; }

    [Binary(3)]
    public byte NumberOfStarts { get; }

    [Binary(4)]
    public byte NumberOfApproaches { get; }

    [Binary(5)]
    public byte NumberOfAprons { get; }

    [Binary(6)]
    public byte NumberOfHelipads { get; }

    [Binary(7)]
    [BinaryReader(typeof(ThreeDimensionalCoordinateReader))]
    public Coordinate Coordinates { get; }

    [Binary(8)]
    [BinaryReader(typeof(ThreeDimensionalCoordinateReader))]
    public Coordinate TowerCoordinates { get; }

    [Binary(9)]
    [BinaryReader(typeof(MagneticVariationReader))]
    public MagneticVariation MagneticVariation { get; }

    [Binary(10)]
    [BinaryReader(typeof(ShiftedIcaoIdentifierReader))]
    public IcaoIdentifier Identifier { get; }

    [Binary(11)]
    [BinaryReader(typeof(IcaoIdentifierReader))]
    public IcaoIdentifier Region { get; }

    [Binary(12)]
    public AirportFuelFlags FuelTypeInfo { get; }
    
    [Binary(13)]
    public byte Unknown { get; }

    [Binary(14)]
    [BinaryReader(typeof(TrafficScalarReader))]
    public double TrafficScalar { get; }

    [Binary(15)]
    [BinaryReader(typeof(IsSlopedValueReader))]
    public bool IsSloped { get; }
    
    [Binary(16)]
    [BinaryConsume(4)]
    [BinaryCondition<AirportType>(nameof(Type), BinaryComparison.Equal, AirportType.P3Dv5)]
    public byte[] Padding { get; }

    [Binary(17)]
    [BinaryPolymorphicCollection(typeof(AirportSubsectionDataFactory), typeof(AirportSubsectionDataType))]
    public ICollection<BglRecord> Subsections { get; } = new List<BglRecord>();
}