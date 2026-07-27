using BglReader.Airport;
using BglReader.Airport.Subsections;
using BglReader.Airport.Subsections.Taxi;
using BglReader.Airport.Subsections.Types;

namespace BglReader.UnitTests.Airport;

public record ExpectedApronRecord(
    SurfaceType SurfaceType,
    SurfaceQuery SurfaceQuery,
    Flatten Flatten,
    Guid MaterialSet,
    Elevation Elevation,
    ushort NumberOfVertices,
    Coordinate[] Vertices);