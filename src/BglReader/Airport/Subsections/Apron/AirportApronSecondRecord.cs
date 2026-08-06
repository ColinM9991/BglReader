using BglReader.Airport.Subsections.Types;
using BglReader.Generic;
using BglReader.Types;
using BglReader.ValueObjects.BitFields;

namespace BglReader.Airport.Subsections.Apron;

[BinarySerializable]
public partial class AirportApronSecondRecord : BglRecord, IAirportApronRecord
{
    [Binary(1)]
    public SurfaceType SurfaceType { get; }
    
    [Binary(2)]
    public SurfaceFlags Flags { get; }
    
    [Binary(3)]
    [BinaryReader(typeof(GuidValueReader))]
    public Guid? MaterialSet { get; }
    
    [Binary(4)]
    [BinaryReader(typeof(ElevationBinaryValueReader))]
    public Elevation Elevation { get; }
    
    [Binary(5)]
    public ushort NumberOfVertices { get; }

    [Binary(6)]
    public ushort NumberOfTriangles { get; }
    
    [Binary(7)]
    [BinaryReader(typeof(TwoDimensionalCoordinateReader))]
    [BinaryCollection(nameof(NumberOfVertices))]
    public ICollection<Coordinate> Vertices { get; }

    [Binary(8)]
    [BinaryReader(typeof(ApronTriangleReader))]
    [BinaryCollection(nameof(NumberOfTriangles))]
    public ICollection<ApronTriangle> Triangles { get; }

}