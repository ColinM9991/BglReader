using BglReader.Generic;
using BglReader.ValueObjects;

namespace BglReader.Navigation;

public class GeopolRecord : BglRecord
{
    public GeopolRecord(BinaryReader reader) : base(reader)
    {
        Flags = new GeoPolFlags(reader.ReadUInt16());
        
        MinimumCoordinates = Coordinate.FromBgl(reader.ReadInt32(), reader.ReadInt32());
        MaximumCoordinates = Coordinate.FromBgl(reader.ReadInt32(), reader.ReadInt32());

        for (var i = 0; i < Flags.NumberOfVertices; i++)
        {
            Vertices.Add(Coordinate.FromBgl(reader.ReadInt32(), reader.ReadInt32()));
        }
    }
    
    public GeoPolFlags Flags { get; }
    
    public Coordinate MinimumCoordinates { get; }
    
    public Coordinate MaximumCoordinates { get; }
    
    public ICollection<Coordinate> Vertices { get; } = new List<Coordinate>();
}

public enum GeoPolType
{
    Coastline = 0x40,
    Boundary = 0x80,
    DashedBoundary = 0x81
}