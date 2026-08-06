using BglReader.Generic;
using BglReader.Types;
using BglReader.ValueObjects.BitFields;

namespace BglReader.Navigation;

[BinarySerializable]
public partial class GeopolRecord : BglRecord
{
    [Binary(1)]
    public GeoPolFlags Flags { get; }
    
    private int NumberOfVertices => Flags.NumberOfVertices;
    
    [Binary(2)]
    [BinaryReader(typeof(TwoDimensionalCoordinateReader))]
    public Coordinate MinimumCoordinates { get; }
    
    [Binary(3)]
    [BinaryReader(typeof(TwoDimensionalCoordinateReader))]
    public Coordinate MaximumCoordinates { get; }
    
    [Binary(4)]
    [BinaryReader(typeof(TwoDimensionalCoordinateReader))]
    [BinaryCollection(nameof(NumberOfVertices))]
    public ICollection<Coordinate> Vertices { get; } = new List<Coordinate>();
}

public enum GeoPolType
{
    Coastline = 0x40,
    Boundary = 0x80,
    DashedBoundary = 0x81
}