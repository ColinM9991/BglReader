using BglReader.Generic;

namespace BglReader.Navigation;

public class WaypointRecord : BglRecord
{
    public WaypointRecord(BinaryReader reader) : base(reader, false)
    {
        Type = (WaypointType)reader.ReadByte();
        NumberOfRoutes = reader.ReadByte();
        Coordinate = new Coordinate(reader.ReadInt32(), reader.ReadInt32());
        MagneticVariation = reader.ReadSingle();
        Identifier = IcaoIdentifier.Parse(reader.ReadUInt32(), true);

        var identFlags = reader.ReadUInt32();
        
        Region = IcaoIdentifier.Parse(identFlags & 0x7FF);
        Airport = IcaoIdentifier.Parse((identFlags >> 11) & 0x1FFFFF);

        MapRoutes(reader);

        reader.BaseStream.Position = GetRecordEndPosition();
    }
    
    public WaypointType Type { get; }
    
    public byte NumberOfRoutes { get; }
    
    public Coordinate Coordinate { get; }
    
    public float MagneticVariation { get; }
    
    public IcaoIdentifier Identifier { get; }
    
    public IcaoIdentifier Region { get; }
    
    public IcaoIdentifier Airport { get; }

    public ICollection<WaypointRoute> Routes { get; } = new List<WaypointRoute>();
    
    private void MapRoutes(BinaryReader reader)
    {
        if (NumberOfRoutes == 0) return;

        for (var i = 0; i < NumberOfRoutes; i++)
        {
            Routes.Add(new WaypointRoute(reader));
        }
    }
}