using BglReader.Airport;

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