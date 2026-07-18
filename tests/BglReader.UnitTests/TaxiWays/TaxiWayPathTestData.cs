using BglReader.Airport;
using BglReader.ValueObjects;

namespace BglReader.UnitTests.TaxiWays;

public static class TaxiWayPathTestData
{
    public static TheoryData<string, string, ExpectedTaxiPathData[]> TaxiWayPathData => new()
    {
        {
            "KTST_TestAirport.bgl",
            "KTST",
            [
                new ExpectedTaxiPathData(
                    0,
                    1,
                    RunwayDesignator.None,
                    SurfacePointType.Runway,
                    true,
                    true,
                    false, 18,
                    SurfaceLineFlags.From(true, true, EdgeMarkingType.Solid, true, EdgeMarkingType.Solid, true),
                    SurfaceType.Asphalt,
                    30.48f,
                    500000),
                new ExpectedTaxiPathData(
                    1,
                    2,
                    RunwayDesignator.None,
                    SurfacePointType.Taxi,
                    true,
                    true,
                    false,
                    0,
                    SurfaceLineFlags.From(true, false, EdgeMarkingType.Dashed, false, EdgeMarkingType.Dashed, false),
                    SurfaceType.Asphalt,
                    23.00f,
                    300000),
                new ExpectedTaxiPathData(
                    2,
                    3,
                    RunwayDesignator.None,
                    SurfacePointType.Path,
                    false,
                    false,
                    false,
                    1,
                    SurfaceLineFlags.From(true, false, EdgeMarkingType.None, false, EdgeMarkingType.None, false),
                    SurfaceType.Asphalt,
                    23.00f,
                    300000),
                new ExpectedTaxiPathData(
                    3,
                    0, // TODO: According to LM P3D documentation, this should be the parking index
                    RunwayDesignator.None,
                    SurfacePointType.Parking,
                    true,
                    true,
                    false,
                    1,
                    SurfaceLineFlags.From(false, false, EdgeMarkingType.None, false, EdgeMarkingType.None, false),
                    SurfaceType.Asphalt,
                    20.00f,
                    150000),
                new ExpectedTaxiPathData(
                    3,
                    4,
                    RunwayDesignator.None,
                    SurfacePointType.Path,
                    false,
                    false,
                    false,
                    0,
                    SurfaceLineFlags.From(false, false, EdgeMarkingType.None, false, EdgeMarkingType.None, false),
                    SurfaceType.Asphalt,
                    18.00f,
                    150000),
                new ExpectedTaxiPathData(
                    4,
                    1, // TODO: According to LM P3D documentation, this should be the parking index
                    RunwayDesignator.None,
                    SurfacePointType.Parking,
                    true,
                    true,
                    false,
                    0,
                    SurfaceLineFlags.From(false, false, EdgeMarkingType.None, false, EdgeMarkingType.None, false),
                    SurfaceType.Asphalt,
                    18.00f,
                    150000),
            ]
        }
    };
}