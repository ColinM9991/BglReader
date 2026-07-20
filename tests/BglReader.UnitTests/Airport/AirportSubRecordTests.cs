using BglReader.Airport;
using BglReader.ValueObjects;

namespace BglReader.UnitTests;

public class AirportSubRecordTests : TestBase
{
    [Fact]
    public void AirportSection_Parsed()
    {
        var airportSection = GetBglFile(FileName).Sections.FirstOrDefault(x => x.Type is SectionType.Airport);
        airportSection.ShouldNotBeNull();
        airportSection.SubsectionsCount.ShouldBe(airportSection.Subsections.Length);

        var airportSubsection = airportSection.Subsections.First();
        airportSubsection.ShouldNotBeNull();
        airportSubsection.Data.ShouldHaveSingleItem();
    }

    [Fact]
    public void AirportSubsection_Parsed()
    {
        var airport = GetBglFile(FileName).GetAirport("KTST");

        airport.ShouldNotBeNull();

        airport.IsSloped.ShouldBeFalse();
        airport.TrafficScalar.ShouldBe(0.6);
        airport.Identifier.ToString().ShouldBe("KTST");
        airport.MagneticVariation.ToString().ShouldBe("-3.5");
        airport.Coordinates.Latitude.ShouldBe(Latitude.Quantized(41.35186742));
        airport.Coordinates.Longitude.ShouldBe(Longitude.Quantized(-89.15308328));
        airport.Coordinates.Elevation.GetValueOrDefault().ShouldBe(new Elevation(199.339f));
        airport.TowerCoordinates.Latitude.ShouldBe(Latitude.Quantized(41.35226742));
        airport.TowerCoordinates.Longitude.ShouldBe(Longitude.Quantized(-89.15258328));
    }

    [Fact]
    public void AirportComRecords_Parsed()
    {
        var airport = GetBglFile(FileName).GetAirport("KTST");

        airport.ShouldNotBeNull();

        var comRecords = airport.Subsections.OfType<AirportComRecord>().ToList();

        comRecords.Count.ShouldBe(4);

        comRecords.ShouldContain(x =>
            x.Frequency.Equals((Frequency)118300000) && x.Type == ComType.Tower && x.Name == "TESTFIELD TOWER");

        comRecords.ShouldContain(x =>
            x.Frequency.Equals((Frequency)121900000) && x.Type == ComType.Ground && x.Name == "TESTFIELD GROUND");

        comRecords.ShouldContain(x =>
            x.Frequency.Equals((Frequency)126000000) && x.Type == ComType.Atis && x.Name == "TESTFIELD ATIS");

        comRecords.ShouldContain(x =>
            x.Frequency.Equals((Frequency)122950000) && x.Type == ComType.Unicom && x.Name == "TESTFIELD UNICOM");
    }

    [Fact]
    public void AirportRunwayRecords_Parsed()
    {
        var runwayRecord = GetBglFile(FileName).GetAirport("KTST").GetRunway(18);
        runwayRecord.ShouldNotBeNull();

        var expectedCoordinate = new Coordinate(Longitude.Quantized(-89.15309158), Latitude.Quantized(41.35184943),
            new Elevation(199.339));
        runwayRecord.Coordinates.Longitude.ShouldBe(expectedCoordinate.Longitude);
        runwayRecord.Coordinates.Latitude.ShouldBe(expectedCoordinate.Latitude);
        runwayRecord.Coordinates.Elevation!.Value.Value.ShouldBe(expectedCoordinate.Elevation!.Value.Value, 0.0001f);
        runwayRecord.SurfaceType.ShouldBe(SurfaceType.Asphalt);
        runwayRecord.Heading.ShouldBe(179.580000f, 0.000001f);
        runwayRecord.Length.ShouldBe(1828.8f);
        runwayRecord.Width.ShouldBe(30.48f);
        runwayRecord.RunwayNumber.ShouldBe((byte)18);
        runwayRecord.Designator.ShouldBe(RunwayDesignator.None);
        runwayRecord.PatternAltitude.ShouldBe(304.799988f);
        runwayRecord.PrimaryIlsIdentifier.ToString().ShouldBe("ITST");
        runwayRecord.SecondaryIlsIdentifier.ToString().ShouldBe(string.Empty);
        runwayRecord.SecondaryRunwayNumber.ShouldBe((byte)36);
        runwayRecord.SecondaryRunwayDesignator.ShouldBe(RunwayDesignator.None);

        runwayRecord.PatternFlags.PrimaryTakeoff.Value.ShouldBeTrue();
        runwayRecord.PatternFlags.PrimaryLanding.Value.ShouldBeTrue();
        runwayRecord.PatternFlags.SecondaryTakeoff.Value.ShouldBeTrue();
        runwayRecord.PatternFlags.SecondaryLanding.Value.ShouldBeTrue();
        runwayRecord.PatternFlags.PrimaryPattern.ShouldBe(RunwayPatternDirection.Left);
        runwayRecord.PatternFlags.SecondaryPattern.ShouldBe(RunwayPatternDirection.Right);

        runwayRecord.LightsFlags.Center.ShouldBe(RunwayLightIntensity.Medium);
        runwayRecord.LightsFlags.Edge.ShouldBe(RunwayLightIntensity.High);
        runwayRecord.LightsFlags.CenterRed.ShouldBeTrue();

        runwayRecord.MarkingFlags.ShouldBe(RunwayMarkingFlags.Edges | RunwayMarkingFlags.Threshold |
                                              RunwayMarkingFlags.FixedDistance | RunwayMarkingFlags.Touchdown |
                                              RunwayMarkingFlags.Dashes | RunwayMarkingFlags.Ident |
                                              RunwayMarkingFlags.Precision | RunwayMarkingFlags.EdgePavement);
    }

    [Theory]
    [InlineData("KTST", 18, RunwayDesignator.None, StartType.Runway, 179.580002, -89.15309158, 41.35184943, 199.339)]
    [InlineData("KTST", 36, RunwayDesignator.None, StartType.Runway, 359.580000, -89.15309158, 41.36184943, 199.339)]
    public void AirportRunway_Start_Parsed(
        string airportName,
        int expectedRunwayNumber,
        RunwayDesignator expectedRunwayDesignator,
        StartType expectedStartType,
        float expectedHeading,
        double expectedLongitude,
        double expectedLatitude,
        double expectedElevation)
    {
        var runwayStartRecords = GetBglFile(FileName).GetAirport(airportName).GetRunwayStarts();
        runwayStartRecords.ShouldNotBeEmpty();
        
        var runwayStartRecord = runwayStartRecords.FirstOrDefault(x => x.RunwayNumber == expectedRunwayNumber);
        
        runwayStartRecord.ShouldNotBeNull();
        
        var expectedCoordinate = new Coordinate(Longitude.Quantized(expectedLongitude), Latitude.Quantized(expectedLatitude), new Elevation(expectedElevation));
        runwayStartRecord.Coordinates.Longitude.ShouldBe(expectedCoordinate.Longitude);
        runwayStartRecord.Coordinates.Latitude.ShouldBe(expectedCoordinate.Latitude);
        runwayStartRecord.Coordinates.Elevation!.Value.Value.ShouldBe(expectedCoordinate.Elevation!.Value.Value, 0.0001f);
        runwayStartRecord.Heading.ShouldBe(expectedHeading, 0.000001);
        runwayStartRecord.Flags.Designator.ShouldBe(expectedRunwayDesignator);
        runwayStartRecord.Flags.StartType.ShouldBe(expectedStartType);
    }
}