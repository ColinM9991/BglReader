using BglReader.Airport;
using BglReader.Airport.Subsections;
using BglReader.Airport.Subsections.RunwayDetails;
using BglReader.Airport.Subsections.Taxi;
using BglReader.Airport.Subsections.Types;
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
    float WeightLimit,
    SurfaceQuery SurfaceQuery,
    Flatten Flatten);