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
        var taxiWayPoint = GetBglFile(fileName)
            .GetAirport(identifier)
            .GetSubRecordByType<AirportTaxiwayPoint>()
            .Single();

        taxiWayPoint.Should().NotBeNull();
        
        taxiWayPoint.NumberOfPoints.Should().Be((ushort)expectedTaxiWayPoints.Length);
        taxiWayPoint.Points.Should().BeEquivalentTo(expectedTaxiWayPoints);
    }
}