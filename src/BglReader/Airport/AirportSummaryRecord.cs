using BglReader.Generic;
using BglReader.Types;
using BglReader.ValueObjects.BitFields;

namespace BglReader.Airport;

[BinarySerializable]
public partial class AirportSummaryRecord : BglRecord
{
    [Binary(1)]
    public AirportSummaryComFlags ComFlags { get; }
    
    [Binary(2)]
    [BinaryReader(typeof(ThreeDimensionalCoordinateReader))]
    public Coordinate Coordinate { get; }
    
    [Binary(3)]
    [BinaryReader(typeof(ShiftedIcaoIdentifierReader))]
    public IcaoIdentifier Identifier { get; }
    
    [Binary(4)]
    [BinaryReader(typeof(IcaoIdentifierReader))]
    public IcaoIdentifier Region { get; }
    
    [Binary(5)]
    [BinaryReader(typeof(MagneticVariationReader))]
    public MagneticVariation MagneticVariation { get; }
    
    [Binary(6)]
    public float LongestRunwayLength { get; }
    
    [Binary(7)]
    public float LongestRunwayHeading { get; }
    
    [Binary(8)]
    public AirportFuelFlags FuelFlags { get; }
}