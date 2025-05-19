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
        var region = identFlags & ((1 << 11) - 1);
        var airport = (identFlags >> 11) & ((1 << 21) - 1);
        
        Region = IcaoIdentifier.Parse(region);
        Airport = IcaoIdentifier.Parse(airport);
    }
    
    public WaypointType Type { get; }
    
    public byte NumberOfRoutes { get; }
    
    public Coordinate Coordinate { get; }
    
    public float MagneticVariation { get; }
    
    public IcaoIdentifier Identifier { get; }
    
    public IcaoIdentifier Region { get; }
    
    public IcaoIdentifier Airport { get; }
}

public enum WaypointType : byte
{
    Named = 1,
    Unnamed = 2,
    VOR = 3,
    NDB = 4,
    OffRoute = 5,
    IAF = 6,
    FAF = 7
}