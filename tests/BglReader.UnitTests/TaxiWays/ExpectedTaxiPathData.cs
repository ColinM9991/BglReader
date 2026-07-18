using BglReader.Airport;
using BglReader.ValueObjects;

namespace BglReader.UnitTests.TaxiWays;

public record ExpectedTaxiPathData(
    ushort StartIndex,
    ushort EndIndex,
    RunwayDesignator Designator,
    SurfacePointType SurfacePointType,
    bool DrawSurface,
    bool DrawDetail,
    bool Reserved,
    byte Value,
    SurfaceLineFlags SurfaceLineFlags,
    SurfaceType Surface,
    float Width,
    float WeightLimit);