using BglReader.Airport;
using FluentAssertions;

namespace BglReader.UnitTests;

public class AirportSubRecordTests : TestBase
{
    [Fact]
    public void AirportSection_Parsed()
    {
        var airportSection = GetBglFile(FileName).Sections.FirstOrDefault(x => x.Type is SectionType.Airport);
        airportSection.Should().NotBeNull();
        airportSection.SubsectionsCount.Should().Be(airportSection.Subsections.Length);

        var airportSubsection = airportSection.Subsections.First();
        airportSubsection.Should().NotBeNull();
        airportSubsection.Data.Should().ContainSingle();
    }

    [Fact]
    public void AirportSubsection_Parsed()
    {
        var airport = GetAirportSubsectionData();

        airport.Should().NotBeNull();

        airport.IsSloped.Should().BeFalse();
        airport.TrafficScalar.Should().Be(0.6);
        airport.Identifier.ToString().Should().Be("KTST");
        airport.MagneticVariation.ToString().Should().Be("-3.5");
        airport.Coordinates.Latitude.Should().BeApproximately(41.35186742, 0.0000001);
        airport.Coordinates.Longitude.Should().BeApproximately(-89.15308328, 0.0000002);
        airport.Coordinates.Elevation.Should().BeApproximately(199.33918762f, 0.0002f);
    }

    [Fact]
    public void AirportComRecords_Parsed()
    {
        var airport = GetAirportSubsectionData();

        airport.Should().NotBeNull();

        var comRecords = airport.Subsections.OfType<AirportComRecord>().ToList();

        comRecords.Should().HaveCount(4);

        comRecords.Should().Contain(x =>
            x.Frequency.Equals((Frequency)118300000) && x.Type == ComType.Tower && x.Name == "TESTFIELD TOWER");

        comRecords.Should().Contain(x =>
            x.Frequency.Equals((Frequency)121900000) && x.Type == ComType.Ground && x.Name == "TESTFIELD GROUND");

        comRecords.Should().Contain(x =>
            x.Frequency.Equals((Frequency)126000000) && x.Type == ComType.Atis && x.Name == "TESTFIELD ATIS");

        comRecords.Should().Contain(x =>
            x.Frequency.Equals((Frequency)122950000) && x.Type == ComType.Unicom && x.Name == "TESTFIELD UNICOM");
    }

    private AirportSubsectionData? GetAirportSubsectionData() => GetBglFile(FileName).Sections
        .First(x => x.Type is SectionType.Airport)
        .Subsections
        .First()
        .Data
        .First(x => x is AirportSubsectionData) as AirportSubsectionData;
}