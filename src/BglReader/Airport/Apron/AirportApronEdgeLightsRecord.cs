using BglReader.Generic;

namespace BglReader.Airport.Apron;

public class AirportApronEdgeLightsRecord : BglRecord
{
    // TODO Validate
    public AirportApronEdgeLightsRecord(
        BglBinaryReader reader) : base(reader)
    {
        _ = reader.ReadBytes(2);

        NumberOfVertices = reader.ReadUInt16();
        NumberOfEdges = reader.ReadUInt16();
        LightColor = reader.ReadUInt32();
        LightIntensity = reader.ReadSingle();
        MaxRenderAltitude = reader.ReadSingle();
        
        Vertices = Enumerable.Range(0, NumberOfVertices)
            .Select(_ => reader.ReadCoordinates(hasElevation: false))
            .ToList();
        
        Edges = Enumerable.Range(0, NumberOfEdges)
            .Select(_ => reader.ReadTriangle())
            .ToList();
    }

    public ushort NumberOfVertices { get; }

    public ushort NumberOfEdges { get; }

    public uint LightColor { get; }

    public float LightIntensity { get; }

    public float MaxRenderAltitude { get; }

    public ICollection<Coordinate> Vertices { get; }

    public ICollection<Triangle> Edges { get; }
}