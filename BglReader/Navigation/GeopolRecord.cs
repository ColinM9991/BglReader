namespace BglReader.Navigation;

public class GeopolRecord : BglRecord
{
    public GeopolRecord(BinaryReader reader) : base(reader)
    {
        var flags = reader.ReadUInt16();

        NumberOfVertices = flags & 0x3FFF;
        Type = (GeopolType)((flags >> 14) & 0x3);
        
        MinimumCoordinates = new Coordinate(reader.ReadInt32(), reader.ReadInt32());
        MaximumCoordinates = new Coordinate(reader.ReadInt32(), reader.ReadInt32());

        for (var i = 0; i < NumberOfVertices; i++)
        {
            Vertices.Add(new Coordinate(reader.ReadInt32(), reader.ReadInt32()));
        }
    }
    
    public int NumberOfVertices { get; }
    
    public GeopolType Type { get; }
    
    public Coordinate MinimumCoordinates { get; }
    
    public Coordinate MaximumCoordinates { get; }
    
    public ICollection<Coordinate> Vertices { get; } = new List<Coordinate>();
}

public enum GeopolType
{
    Coastline = 0x40,
    Boundary = 0x80,
    DashedBoundary = 0x81
}