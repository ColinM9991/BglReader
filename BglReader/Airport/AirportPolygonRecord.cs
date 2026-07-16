using BglReader.Generic;

namespace BglReader.Airport;

public class AirportPolygonRecord : BglRecord
{
    public AirportPolygonRecord(BinaryReader reader) : base(reader)
    {
        _ = reader.ReadBytes(2);

        var numberOfVertices = reader.ReadUInt16();
        var numberOfTriangles = reader.ReadUInt16();
        MapVertices(reader, numberOfVertices);
        MapTriangles(reader, numberOfTriangles);
    }
    
    public ICollection<Coordinate> Vertices { get; } = new List<Coordinate>();
    
    public ICollection<Triangle> Triangles { get; } = new List<Triangle>();

    private void MapVertices(BinaryReader reader, ushort numberOfVertices)
    {
        if (numberOfVertices == 0) return;

        for (var vertex = 0; vertex < numberOfVertices; vertex++)
        {
            Vertices.Add(Coordinate.FromBgl(
                reader.ReadInt32(),
                reader.ReadInt32()));
        }
    }

    private void MapTriangles(BinaryReader reader, ushort numberOfVertices)
    {
        if (numberOfVertices == 0) return;

        for (var edge = 0; edge < numberOfVertices; edge++)
        {
            Triangles.Add(new Triangle(
                reader.ReadSingle(),
                reader.ReadUInt16(),
                reader.ReadUInt16()));
        }
    }
}