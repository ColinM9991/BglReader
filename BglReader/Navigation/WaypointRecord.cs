using BglReader.Generic;
using BglReader.ValueObjects;

namespace BglReader.Navigation;

public class WaypointRecord : BglRecord
{
    public WaypointRecord(BglBinaryReader reader) : base(reader, false)
    {
        Type = (WaypointType)reader.ReadByte();
        NumberOfRoutes = reader.ReadByte();
        Coordinate = reader.ReadCoordinates(hasElevation: false);
        MagneticVariation = (MagneticVariation)reader.ReadSingle();
        Identifier = new ShiftedIcaoIdentifier(reader.ReadUInt32());

        RegionFlags = new RegionIdentifierFlags(reader.ReadUInt32());

        MapRoutes(reader);

        reader.Position = GetRecordEndPosition();
    }
    
    public WaypointType Type { get; }
    
    public byte NumberOfRoutes { get; }
    
    public Coordinate Coordinate { get; }
    
    public MagneticVariation MagneticVariation { get; }
    
    public ShiftedIcaoIdentifier Identifier { get; }
    
    public RegionFlags RegionFlags { get; }

    public ICollection<WaypointRoute> Routes { get; } = new List<WaypointRoute>();
    
    private void MapRoutes(BglBinaryReader reader)
    {
        if (NumberOfRoutes == 0) return;

        for (var i = 0; i < NumberOfRoutes; i++)
        {
            Routes.Add(new WaypointRoute(reader));
        }
    }
}