using BglReader.Airport.Subsections.Types;
using BglReader.Types;

namespace BglReader.UnitTests.Airport;

public record ExpectedSecondApronRecord(
    SurfaceType SurfaceType,
    bool DrawSurface,
    bool DrawDetail,
    Guid MaterialSet,
    Elevation Elevation,
    ushort NumberOfVertices,
    ushort NumberOfTriangles,
    Coordinate[] Vertices);