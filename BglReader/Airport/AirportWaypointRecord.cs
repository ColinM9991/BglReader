namespace BglReader.Airport;

public class AirportWaypointRecord : BglRecord
{
    public AirportWaypointRecord(BinaryReader reader) : base(reader)
    {
        Type = (WaypointType)reader.ReadByte();
        NumberOfRoutes = reader.ReadByte();
        Coordinate = new Coordinate(reader.ReadInt32(), reader.ReadInt32());
        MagneticVariation = reader.ReadSingle();
        Identifier = IcaoIdentifier.Parse(reader.ReadUInt32(), true);

        var identFlags = reader.ReadUInt32();
        
        Region = IcaoIdentifier.Parse(identFlags & 0x7FF);
        Airport = IcaoIdentifier.Parse((identFlags >> 11) & 0x1FFFFF);
    }
    
    public WaypointType Type { get; }
    
    public byte NumberOfRoutes { get; }
    
    public Coordinate Coordinate { get; }
    
    public float MagneticVariation { get; }
    
    public IcaoIdentifier Identifier { get; }
    
    public IcaoIdentifier Region { get; }
    
    public IcaoIdentifier Airport { get; }
}