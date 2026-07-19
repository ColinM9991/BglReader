using BglReader.Generic;

namespace BglReader.Airport;

public class AirportPolygonRecord : BglRecord
{
    public AirportPolygonRecord(BglBinaryReader reader) : base(reader)
    {
        _ = reader.ReadBytes(2);

        var numberOfVertices = reader.ReadUInt16();
        var numberOfTriangles = reader.ReadUInt16();
        
        Vertices = Enumerable.Range(0, numberOfVertices)
            .Select(_ => reader.ReadCoordinates(hasElevation: false))
            .ToList();
        
        Triangles = Enumerable.Range(0, numberOfTriangles)
            .Select(_ => reader.ReadTriangle(false))
            .ToList();
    }
    
    public ICollection<Coordinate> Vertices { get; }
    
    public ICollection<Triangle> Triangles { get; }
}