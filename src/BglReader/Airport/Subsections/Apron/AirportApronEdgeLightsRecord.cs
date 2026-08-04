using BglReader.Airport.Subsections.Types;
using BglReader.Generic;
using BglReader.Types;

namespace BglReader.Airport.Subsections.Apron;

//TODO Validate
[BinarySerializable]
public partial class AirportApronEdgeLightsRecord : BglRecord
{
    [Binary(1)]
    [BinaryConsume(2)]
    public byte[] Unknown { get; }

    [Binary(2)]
    public ushort NumberOfVertices { get; }

    [Binary(3)]
    public ushort NumberOfEdges { get; }

    [Binary(4)]
    public uint LightColor { get; }

    [Binary(5)]
    public float LightIntensity { get; }

    [Binary(6)]
    public float MaxRenderAltitude { get; }

    [Binary(7)]
    [BinaryReader(typeof(TwoDimensionalCoordinateReader))]
    [BinaryCollection(nameof(NumberOfVertices))]
    public ICollection<Coordinate> Vertices { get; }

    [Binary(8)]
    [BinaryReader(typeof(PrecisionTriangleReader))]
    [BinaryCollection(nameof(NumberOfEdges))]
    public ICollection<Triangle> Edges { get; }
}