using BglReader.Generic;
using BglReader.ValueObjects;

namespace BglReader.Navigation;

public class GeopolRecord : BglRecord
{
    public GeopolRecord(BglBinaryReader reader) : base(reader)
    {
        Flags = new GeoPolFlags(reader.ReadUInt16());
        
        MinimumCoordinates = reader.ReadCoordinates(hasElevation: false);
        MaximumCoordinates = reader.ReadCoordinates(hasElevation: false);

        for (var i = 0; i < Flags.NumberOfVertices; i++)
        {
            Vertices.Add(reader.ReadCoordinates(hasElevation: false));
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