using BglReader.Airport;

namespace BglReader.UnitTests.TaxiWayPoints;

public static class TaxiWayPointTestData
{
    public static TheoryData<string, string, TaxiWayPoint[]> TaxiWayPointsData => new()
    {
        {
            "KTST_TestAirport.bgl",
            "KTST",
            [
                new TaxiWayPoint(TaxiPointType.Normal, TaxiPointFlag.Forward,
                    Coordinate.FromBgl(203221094, 145095778, 199500)),
                new TaxiWayPoint(TaxiPointType.HoldShort, TaxiPointFlag.Forward,
                    Coordinate.FromBgl(203221113, 145106759, 199500)),
                new TaxiWayPoint(TaxiPointType.IlsHoldShort, TaxiPointFlag.Reverse,
                    Coordinate.FromBgl(203221113, 145102733, 199500)),
                new TaxiWayPoint(TaxiPointType.Normal, TaxiPointFlag.Forward,
                    Coordinate.FromBgl(203224325, 145107296, 199500)),
                new TaxiWayPoint(TaxiPointType.Normal, TaxiPointFlag.Forward,
                    Coordinate.FromBgl(203225773, 145095329, 199500)),
            ]
        }
    };
}