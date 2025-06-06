using BglReader.Generic;

namespace BglReader.Airport;

public class AirportApronEdgeLightsRecord : BglRecord
{
    // TODO Validate
    public AirportApronEdgeLightsRecord(
        BinaryReader reader) : base(reader)
    {
        _ = reader.ReadBytes(2);

        NumberOfVertices = reader.ReadUInt16();
        NumberOfEdges = reader.ReadUInt16();
        LightColor = reader.ReadUInt32();
        LightIntensity = reader.ReadSingle();
        MaxRenderAltitude = reader.ReadSingle();
        MapVertices(reader);
        MapLightEdges(reader);
    }

    public ushort NumberOfVertices { get; }

    public ushort NumberOfEdges { get; }

    public uint LightColor { get; }

    public float LightIntensity { get; }

    public float MaxRenderAltitude { get; }

    public ICollection<Coordinate> Vertices { get; } = new List<Coordinate>();

    public ICollection<Triangle> Edges { get; } = new List<Triangle>();

    private void MapVertices(BinaryReader reader)
    {
        if (NumberOfVertices == 0) return;

        for (var vertex = 0; vertex < NumberOfVertices; vertex++)
        {
            Vertices.Add(new Coordinate(
                reader.ReadInt32(),
                reader.ReadInt32()));
        }
    }

    private void MapLightEdges(BinaryReader reader)
    {
        if (NumberOfEdges == 0) return;

        for (var edge = 0; edge < NumberOfEdges; edge++)
        {
            Edges.Add(new Triangle(
                reader.ReadSingle(),
                reader.ReadUInt16(),
                reader.ReadUInt16()));
        }
    }
}