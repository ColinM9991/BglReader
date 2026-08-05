namespace BglReader.Navigation;

[BinarySerializable]
public sealed partial class WaypointRoute
{
    [Binary(1)]
    public RouteType Type { get; }

    [Binary(2)]
    [BinaryString(8)]
    public string Name { get; }
    
    [Binary(3)]
    public WaypointSegment? Next { get; }
    
    [Binary(4)]
    public WaypointSegment? Previous { get; }
}