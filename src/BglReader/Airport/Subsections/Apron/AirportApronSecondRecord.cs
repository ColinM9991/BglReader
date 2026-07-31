using BglReader.Airport.Subsections.Types;
using BglReader.Attributes.BinaryAttributes;
using BglReader.Generic;
using BglReader.Types;
using BglReader.ValueObjects.BitFields;

namespace BglReader.Airport.Subsections.Apron;

[BinarySerializable]
public partial class AirportApronSecondRecord : BglRecord, IAirportApronRecord
{
    [Binary(1)]
    public SurfaceType SurfaceType { get; init; }
    
    [Binary(2)]
    public SurfaceFlags Flags { get; }
    
    [Binary(3)]
    [BinaryReader(typeof(GuidValueReader))]
    public Guid? MaterialSet { get; init; }
    
    [Binary(4)]
    [BinaryReader(typeof(ElevationBinaryValueReader))]
    public Elevation Elevation { get; init; }
    
    [Binary(5)]
    public ushort NumberOfVertices { get; init; }

    [Binary(6)]
    public ushort NumberOfTriangles { get; }
    
    [Binary(7)]
    [BinaryCollection(nameof(NumberOfVertices))]
    public ICollection<Coordinate> Vertices { get; init; }

    [Binary(8)]
    [BinaryReader(typeof(ApronTriangleReader))]
    [BinaryCollection(nameof(NumberOfTriangles))]
    public ICollection<ApronTriangle> Triangles { get; }

}