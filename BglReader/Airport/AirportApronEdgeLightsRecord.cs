namespace BglReader.Airport;

public class AirportApronEdgeLightsRecord : BglRecord
{
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

    public ushort NumberOfVertices { get; set; }

    public ushort NumberOfEdges { get; set; }

    public uint LightColor { get; set; }

    public float LightIntensity { get; set; }

    public float MaxRenderAltitude { get; set; }

    public ICollection<Coordinate> Vertices { get; } = new List<Coordinate>();

    public ICollection<LightEdge> Edges { get; } = new List<LightEdge>();

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
            Edges.Add(new LightEdge(
                reader.ReadSingle(),
                reader.ReadUInt16(),
                reader.ReadUInt16()));
        }
    }
}