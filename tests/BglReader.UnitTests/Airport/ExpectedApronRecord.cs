using BglReader.Airport;
using BglReader.Airport.Taxi;

namespace BglReader.UnitTests.Airport;

public record ExpectedApronRecord(
    SurfaceType SurfaceType,
    SurfaceQuery SurfaceQuery,
    Flatten Flatten,
    Guid MaterialSet,
    Elevation Elevation,
    ushort NumberOfVertices,
    Coordinate[] Vertices);