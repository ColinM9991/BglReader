using BglReader.Airport;
using BglReader.Airport.Taxi;
using BglReader.ValueObjects;

namespace BglReader.UnitTests.TaxiWays;

public static class TaxiWayParkingTestData
{
    public static TheoryData<string, string, TaxiParking[]> TaxiWayParkingData => new()
    {
        {
            "KTST_TestAirport.bgl",
            "KTST",
            [
                new TaxiParking(
                    TaxiParkingFlags.From(TaxiParkingName.Gate, TurnDirection.Either, ParkingType.GateSmall, 1, 3),
                    20.0f,
                    90.0f,
                    0f,
                    0f,
                    0f,
                    0f,
                    Coordinate.FromBgl(203226220, 145094733, 199339),
                    ["BAW", "AAL", "UAL"]),
                new TaxiParking(
                    TaxiParkingFlags.From(TaxiParkingName.Parking, TurnDirection.Either, ParkingType.RampGASmall, 2, 0),
                    15.0f,
                    270.0f,
                    0f,
                    0f,
                    0f,
                    0f,
                    Coordinate.FromBgl(203226220, 145094733, 199339),
                    []),
            ]
        }
    };
}