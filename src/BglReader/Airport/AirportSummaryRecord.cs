using BglReader.Generic;
using BglReader.ValueObjects;

namespace BglReader.Airport;

public class AirportSummaryRecord : BglRecord
{
    public AirportSummaryRecord(BglBinaryReader reader) : base(reader, false)
    {
        ComFlags = new AirportSummaryComFlags(reader.ReadUInt16());
        Coordinate = reader.ReadCoordinates();
        Identifier = new ShiftedIcaoIdentifier(reader.ReadUInt32());
        Region = new IcaoIdentifier(reader.ReadUInt32());
        MagneticVariation = new MagneticVariation(reader.ReadSingle());
        LongestRunwayLength = reader.ReadSingle();
        LongestRunwayHeading = reader.ReadSingle();
        FuelFlags = new AirportFuelFlags(reader.ReadUInt32());
    }
    
    public AirportSummaryComFlags ComFlags { get; }
    
    public Coordinate Coordinate { get; }
    
    public ShiftedIcaoIdentifier Identifier { get; }
    
    public IcaoIdentifier Region { get; }
    
    public MagneticVariation MagneticVariation { get; }
    
    public float LongestRunwayLength { get; }
    
    public float LongestRunwayHeading { get; }
    
    public AirportFuelFlags FuelFlags { get; }
}