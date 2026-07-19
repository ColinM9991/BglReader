using BglReader.Airport;
using BglReader.Airport.Taxi;

namespace BglReader.UnitTests.Airport;

public static class AirportApronTestData
{
    public static TheoryData<string, string, ExpectedApronRecord[]> AirportApronData => new()
    {
        {
            "KTST_TestAirport.bgl",
            "KTST",
            [
                new ExpectedApronRecord(SurfaceType.Concrete, SurfaceQuery.Default, Flatten.Default, Guid.Empty,
                    new Elevation(199.5f), 4, [
                        Coordinate.FromBgl(203225102, 145095031),
                        Coordinate.FromBgl(203226220, 145095031),
                        Coordinate.FromBgl(203226220, 145094136),
                        Coordinate.FromBgl(203225102, 145094136)
                    ])
            ]
        }
    };

    public static TheoryData<string, string, ExpectedSecondApronRecord[]> AirportSecondApronData => new()
    {
        {
            "KTST_TestAirport.bgl",
            "KTST",
            [
                new ExpectedSecondApronRecord(SurfaceType.Concrete, true, true, Guid.Empty,
                    new Elevation(199.5f), 4, 2, [
                        Coordinate.FromBgl(203225102, 145095031),
                        Coordinate.FromBgl(203226220, 145095031),
                        Coordinate.FromBgl(203226220, 145094136),
                        Coordinate.FromBgl(203225102, 145094136)
                    ])
            ]
        }
    };
}