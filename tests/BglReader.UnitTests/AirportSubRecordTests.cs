using BglReader.Airport;
using BglReader.UnitTests.Helpers;
using BglReader.ValueObjects;
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
        var airport = GetBglFile(FileName).GetAirport("KTST");

        airport.Should().NotBeNull();

        airport.IsSloped.Should().BeFalse();
        airport.TrafficScalar.Should().Be(0.6);
        airport.Identifier.ToString().Should().Be("KTST");
        airport.MagneticVariation.ToString().Should().Be("-3.5");
        airport.Coordinates.Latitude.Should().BeApproximately(41.35186742, 0.0000001);
        airport.Coordinates.Longitude.Should().BeApproximately(-89.15308328, 0.0000002);
        airport.Coordinates.Elevation.Should().BeApproximately(199.33918762f, 0.0002f);
        airport.TowerCoordinates.Latitude.Should().BeApproximately(41.35226742, 0.0000001);
        airport.TowerCoordinates.Longitude.Should().BeApproximately(-89.15258328, 0.0000002);
    }

    [Fact]
    public void AirportComRecords_Parsed()
    {
        var airport = GetBglFile(FileName).GetAirport("KTST");

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

    [Fact]
    public void AirportRunwayRecords_Parsed()
    {
        var runwayRecord = GetBglFile(FileName).GetAirport("KTST").GetRunway(18);
        runwayRecord.Should().NotBeNull();
        
        runwayRecord.Coordinates.Latitude.Should().BeApproximately(41.35184943, 0.0000001);
        runwayRecord.Coordinates.Longitude.Should().BeApproximately(-89.15309158, 0.0000002);
        runwayRecord.Coordinates.Elevation.Should().BeApproximately(199.33918762f, 0.0002f);
        runwayRecord.SurfaceType.Should().Be(SurfaceType.Asphalt);
        runwayRecord.Heading.Should().BeApproximately(179.580000f, 0.000001f);
        runwayRecord.Length.Should().Be(1828.8f);
        runwayRecord.Width.Should().Be(30.48f);
        runwayRecord.RunwayNumber.Should().Be(18);
        runwayRecord.Designator.Should().Be(RunwayDesignator.None);
        runwayRecord.PatternAltitude.Should().Be(304.799988f);
        runwayRecord.PrimaryIlsIdentifier.ToString().Should().Be("ITST");
        runwayRecord.SecondaryIlsIdentifier.ToString().Should().Be(string.Empty);
        runwayRecord.SecondaryRunwayNumber.Should().Be(36);
        runwayRecord.SecondaryRunwayDesignator.Should().Be(RunwayDesignator.None);
        
        runwayRecord.PatternFlags.PrimaryTakeoff.Value.Should().BeTrue();
        runwayRecord.PatternFlags.PrimaryLanding.Value.Should().BeTrue();
        runwayRecord.PatternFlags.SecondaryTakeoff.Value.Should().BeTrue();
        runwayRecord.PatternFlags.SecondaryLanding.Value.Should().BeTrue();
        runwayRecord.PatternFlags.PrimaryPattern.Should().Be(RunwayPatternDirection.Left);
        runwayRecord.PatternFlags.SecondaryPattern.Should().Be(RunwayPatternDirection.Right);

        runwayRecord.LightsFlags.Center.Should().Be(RunwayLightIntensity.Medium);
        runwayRecord.LightsFlags.Edge.Should().Be(RunwayLightIntensity.High);
        runwayRecord.LightsFlags.CenterRed.Should().BeTrue();
        
        runwayRecord.MarkingFlags.Should().Be(RunwayMarkingFlags.Edges | RunwayMarkingFlags.Threshold |
                                              RunwayMarkingFlags.FixedDistance | RunwayMarkingFlags.Touchdown |
                                              RunwayMarkingFlags.Dashes | RunwayMarkingFlags.Ident |
                                              RunwayMarkingFlags.Precision | RunwayMarkingFlags.EdgePavement);
    }

    [Theory]
    [InlineData(FileName, "KTST", 18)]
    public void AirportSubRecord_Offset_Parsed(string fileName, string airportIdentifier, byte runwayNumber)
    {
        var runway = GetBglFile(fileName)
            .GetAirport(airportIdentifier)
            .GetRunway(runwayNumber);

        runway.Should().NotBeNull();

        var offset = runway.SubRecords.OfType<AirportSubReportBaseRecord>().FirstOrDefault(x => x.Id == (int)AirportRecordDataType.OffsetPrimary);
        offset.Should().NotBeNull();

        offset.Type.Should().Be(AirportSubReportBaseRecord.SubReportBaseType.OffsetThreshold);
        offset.SurfaceType.Should().Be(SurfaceType.Concrete);
        offset.Length.Should().Be(76.2f);
        offset.Width.Should().Be(30.48f);
    }
}