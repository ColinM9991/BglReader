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
                        new Coordinate(Longitude.Quantized(-89.15130000), Latitude.Quantized(41.35310000)),
                        new Coordinate(Longitude.Quantized(-89.15080000), Latitude.Quantized(41.35310000)),
                        new Coordinate(Longitude.Quantized(-89.15080000), Latitude.Quantized(41.35340000)),
                        new Coordinate(Longitude.Quantized(-89.15130000), Latitude.Quantized(41.35340000))
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
                        new Coordinate(Longitude.Quantized(-89.15130000), Latitude.Quantized(41.35310000)),
                        new Coordinate(Longitude.Quantized(-89.15080000), Latitude.Quantized(41.35310000)),
                        new Coordinate(Longitude.Quantized(-89.15080000), Latitude.Quantized(41.35340000)),
                        new Coordinate(Longitude.Quantized(-89.15130000), Latitude.Quantized(41.35340000))
                    ])
            ]
        }
    };
}