using BglReader.Airport.Taxi;

namespace BglReader.UnitTests.TaxiWays;

public class TaxiWayPointTests : TestBase
{
    [Theory]
    [MemberData(nameof(TaxiWayPointTestData.TaxiWayPointsData), MemberType = typeof(TaxiWayPointTestData))]
    public void TaxiWayPoints_Parsed(
        string fileName,
        string identifier,
        TaxiWayPoint[] expectedTaxiWayPoints)
    {
        var file = GetBglFile(fileName);
        var taxiWayPoint = file
            .GetAirport(identifier)
            .GetSubRecordByType<AirportTaxiwayPoint>()
            .Single();

        taxiWayPoint.ShouldNotBeNull();
        
        taxiWayPoint.NumberOfPoints.ShouldBe((ushort)expectedTaxiWayPoints.Length);
        for (var i = 0; i < expectedTaxiWayPoints.Length; i++)
        {
            var expected = expectedTaxiWayPoints[i];
            var actual = taxiWayPoint.Points.ElementAt(i);
            
            actual.Coordinate.Longitude.ShouldBeEquivalentTo(expected.Coordinate.Longitude);
            actual.Coordinate.Latitude.ShouldBeEquivalentTo(expected.Coordinate.Latitude);
            actual.Coordinate.Elevation.ShouldBeEquivalentTo(expected.Coordinate.Elevation);
            
            actual.Type.ShouldBeEquivalentTo(expected.Type);
            actual.Flag.ShouldBeEquivalentTo(expected.Flag);
        }
    }
}