using BglReader.Airport.Taxi;

namespace BglReader.UnitTests.TaxiWays;

public class TaxiWayPathTests : TestBase
{
    [Theory]
    [MemberData(nameof(TaxiWayPathTestData.TaxiWayPathData), MemberType = typeof(TaxiWayPathTestData))]
    public void TaxiPathP3DRecords_Parsed(
        string fileName,
        string identifier,
        ExpectedTaxiPathData[] expectedTaxiPaths)
    {
        var taxiPathRecords = GetBglFile(fileName)
            .GetAirport(identifier)
            .GetSubRecordByType<AirportTaxiPathRecord>()
            .Single();

        taxiPathRecords.Should().NotBeNull();
        
        var paths = taxiPathRecords.Paths.OfType<TaxiPathP3D>().ToList();

        const float tolerance = 0.02f;
        foreach (var expectedTaxiPath in expectedTaxiPaths)
        {
            paths.Should().Contain(x =>
                x.StartIndex == expectedTaxiPath.StartIndex
                && x.PathFlags.EndIndex == expectedTaxiPath.EndIndex 
                && x.PathFlags.Designator == expectedTaxiPath.Designator
                && x.TypeFlags.Type == expectedTaxiPath.SurfacePointType
                && x.TypeFlags.DrawDetail.Equals(expectedTaxiPath.DrawDetail)
                && x.TypeFlags.DrawSurface.Equals(expectedTaxiPath.DrawSurface)
                && x.PathValue == expectedTaxiPath.Value
                && x.EdgeFlags.Equals(expectedTaxiPath.SurfaceLineFlags)
                && x.Surface == expectedTaxiPath.Surface
                && x.TerrainFlags.SurfaceQuery == expectedTaxiPath.SurfaceQuery
                && x.TerrainFlags.Flatten == expectedTaxiPath.Flatten
                && Math.Abs(x.Width - expectedTaxiPath.Width) < tolerance
                && Math.Abs(x.WeightLimit - expectedTaxiPath.WeightLimit) < tolerance);
        }
    }
}