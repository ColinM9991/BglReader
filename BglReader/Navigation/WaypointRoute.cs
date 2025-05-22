using System.Text;

namespace BglReader.Navigation;

public struct WaypointRoute
{
    public WaypointRoute(BinaryReader reader)
    {
        Type = (RouteType)reader.ReadByte();
        Name = Encoding.UTF8.GetString(reader.ReadBytes(8));

        Next = WaypointSegment.Parse(reader);
        Previous = WaypointSegment.Parse(reader);
    }

    public RouteType Type { get; }

    public string Name { get; }
    
    public WaypointSegment? Next { get; }
    
    public WaypointSegment? Previous { get; }
}