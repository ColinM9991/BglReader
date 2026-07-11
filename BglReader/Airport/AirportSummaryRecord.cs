using BglReader.Generic;

namespace BglReader.Airport;

public sealed class AirportSummaryRecord : BglRecord
{
    public AirportSummaryRecord(BinaryReader reader) : base(reader)
    {
        ComFlags = new ValueObjects.AirportSummaryComFlags(reader.ReadUInt16());
        Coordinate = new Coordinate(reader.ReadInt32(), reader.ReadInt32(), reader.ReadInt32());
        Identifier = IcaoIdentifier.Parse(reader.ReadUInt32());
        Region = IcaoIdentifier.Parse(reader.ReadUInt32());
        MagneticVariation = new MagneticVariation(reader.ReadSingle());
        LongestRunwayLength = reader.ReadSingle();
        LongestRunwayHeading = reader.ReadSingle();
        FuelFlags = new ValueObjects.AirportFuelFlags(reader.ReadUInt32());
    }
    
    public ValueObjects.AirportSummaryComFlags ComFlags { get; }
    
    public Coordinate Coordinate { get; }
    
    public IcaoIdentifier Identifier { get; }
    
    public IcaoIdentifier Region { get; }
    
    public MagneticVariation MagneticVariation { get; }
    
    public float LongestRunwayLength { get; }
    
    public float LongestRunwayHeading { get; }
    
    public ValueObjects.AirportFuelFlags FuelFlags { get; }
}