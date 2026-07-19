using BglReader.Airport.Apron;

namespace BglReader.UnitTests.Airport;

public class ApronSubRecordTests : TestBase
{
    [Theory]
    [MemberData(nameof(AirportApronTestData.AirportApronData), MemberType = typeof(AirportApronTestData))]
    public void AirportApron_Parsed(string fileName, string identifier, ExpectedApronRecord[] expectedAprons)
    {
        var aprons = GetBglFile(fileName).GetAirport(identifier).GetSubRecordByType<AirportApronRecord>();

        aprons.Should().NotBeNull();
        aprons.Should().NotBeEmpty();
        aprons.Should().HaveCount(expectedAprons.Length);

        foreach (var expectedApron in expectedAprons)
        {
            aprons.Should().Contain(x =>
                x.SurfaceType == expectedApron.SurfaceType
                && x.TerrainFlags.SurfaceQuery == expectedApron.SurfaceQuery
                && x.TerrainFlags.Flatten == expectedApron.Flatten
                && x.MaterialSet == expectedApron.MaterialSet
                && x.Elevation == expectedApron.Elevation
                && x.NumberOfVertices == expectedApron.NumberOfVertices
                && x.Vertices.SequenceEqual(expectedApron.Vertices));
        }
    }
    
    [Theory]
    [MemberData(nameof(AirportApronTestData.AirportSecondApronData), MemberType = typeof(AirportApronTestData))]
    public void AirportSecondApron_Parsed(string fileName, string identifier, ExpectedSecondApronRecord[] expectedAprons)
    {
        var aprons = GetBglFile(fileName).GetAirport(identifier).GetSubRecordByType<AirportApronSecondRecord>();

        aprons.Should().NotBeNull();
        aprons.Should().NotBeEmpty();
        aprons.Should().HaveCount(expectedAprons.Length);

        foreach (var expectedApron in expectedAprons)
        {
            aprons.Should().Contain(x =>
                x.SurfaceType == expectedApron.SurfaceType
                && x.Flags.DrawDetail == expectedApron.DrawDetail
                && x.Flags.DrawSurface == expectedApron.DrawSurface
                && x.MaterialSet == expectedApron.MaterialSet
                && x.Elevation == expectedApron.Elevation
                && x.NumberOfVertices == expectedApron.NumberOfVertices
                && x.NumberOfTriangles == expectedApron.NumberOfTriangles
                && x.Vertices.SequenceEqual(expectedApron.Vertices));
        }
    }
}