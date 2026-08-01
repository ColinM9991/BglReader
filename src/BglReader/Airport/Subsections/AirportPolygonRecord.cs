using BglReader.Airport.Subsections.Types;
using BglReader.Generic;
using BglReader.Types;

namespace BglReader.Airport.Subsections;

[BinarySerializable]
public partial class AirportPolygonRecord : BglRecord
{
    [Binary(1)]
    [BinaryDiscard(2)]
    public byte[] Unknown { get; }
    
    [Binary(2)]
    public ushort NumberOfVertices { get; }
    
    [Binary(3)]
    public ushort NumberOfTriangles { get; }
    
    [Binary(4)]
    [BinaryReader(typeof(TwoDimensionalCoordinateReader))]
    [BinaryCollection(nameof(NumberOfVertices))]
    public ICollection<Coordinate> Vertices { get; }
    
    [Binary(5)]
    [BinaryReader(typeof(TriangleReader))]
    [BinaryCollection(nameof(NumberOfTriangles))]
    public ICollection<Triangle> Triangles { get; }
}