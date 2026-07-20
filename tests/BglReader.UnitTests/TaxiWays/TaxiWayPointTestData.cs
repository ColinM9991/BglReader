using BglReader.Airport.Taxi;

namespace BglReader.UnitTests.TaxiWays;

public static class TaxiWayPointTestData
{
    private static Dictionary<string, Latitude> AirportLatitudes = new()
    {
        ["KTST"] = Latitude.Quantized(41.35186742),
    };

    public static TheoryData<string, string, TaxiWayPoint[]> TaxiWayPointsData()
    {
        const string identifier = "KTST";
        var airportLatitude = AirportLatitudes[identifier];
        return new()
        {
            {
                "KTST_TestAirport.bgl",
                identifier,
                [
                    new TaxiWayPoint(TaxiPointType.Normal, TaxiPointFlag.Forward,
                        new Coordinate(Longitude.Quantized(-89.15309158), Latitude.Quantized(41.35284943),
                            new Elevation(199.500))),
                    new TaxiWayPoint(TaxiPointType.HoldShort, TaxiPointFlag.Forward,
                        new Coordinate(Longitude.Quantized(-89.15308328), Latitude.Quantized(airportLatitude, -300),
                            new Elevation(199.500))),
                    new TaxiWayPoint(TaxiPointType.IlsHoldShort, TaxiPointFlag.Reverse,
                        new Coordinate(Longitude.Quantized(-89.15308328), Latitude.Quantized(airportLatitude, -150),
                            new Elevation(199.500))),
                    new TaxiWayPoint(TaxiPointType.Normal, TaxiPointFlag.Forward,
                        new Coordinate(Longitude.Quantized(-89.15308328, airportLatitude, 120),
                            Latitude.Quantized(airportLatitude, -320.005),
                            new Elevation(199.500))),
                    new TaxiWayPoint(TaxiPointType.Normal, TaxiPointFlag.Forward,
                        new Coordinate(Longitude.Quantized(-89.15100000), Latitude.Quantized(41.35300000),
                            new Elevation(199.500))),
                ]
            }
        };
    }
}