using System.Text;

namespace BglReader.Navigation;

public struct WaypointRoute
{
    public WaypointRoute(BglBinaryReader reader)
    {
        Type = (RouteType)reader.ReadByte();
        Name = reader.ReadString(8);

        Next = WaypointSegment.Parse(reader);
        Previous = WaypointSegment.Parse(reader);
    }

    public RouteType Type { get; }

    public string Name { get; }
    
    public WaypointSegment? Next { get; }
    
    public WaypointSegment? Previous { get; }
}