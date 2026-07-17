using BglReader.Airport;
using BglReader.Generic;
using BglReader.Navigation;

namespace BglReader.UnitTests;

public class IlsVorRecordTests : TestBase
{
    [Theory]
    [InlineData(
        "ITST",
        IlsVorType.ILS,
        203221094,
        145218066,
        199339,
        110350000,
        33344.5273,
        -3.5f,
        "KTST",
        true,
        false,
        true,
        false,
        false)]
    public void ILS_VOR_Record_Parsed(
        string identifier,
        IlsVorType expectedType,
        int longitude,
        int latitude,
        int elevation,
        uint expectedFrequency,
        float expectedRange,
        MagneticVariation expectedMagneticVariation,
        string expectedRegionIdentifier,
        bool expectedIsDme,
        bool expectedIsBackCourse,
        bool expectedHasGlideslope,
        bool expectedIsDmePresent,
        bool expectedNavTrue)
    {
        var ilsVorRecord = GetBglFile(FileName)
            .GetIlsVorRecord(identifier);

        ilsVorRecord.Should().NotBeNull();
        ilsVorRecord.Type.Should().Be(expectedType);
        ilsVorRecord.Coordinates.Should().BeEquivalentTo(Coordinate.FromBgl(longitude, latitude, elevation));
        ilsVorRecord.Frequency.Should().BeEquivalentTo((Frequency)expectedFrequency);
        ilsVorRecord.Range.Should().Be(expectedRange);
        ilsVorRecord.MagneticVariation.Should().Be(expectedMagneticVariation);
        ilsVorRecord.RegionFlags.Identifier.ToString().Should().Be(expectedRegionIdentifier);
        ilsVorRecord.Flags.IsNotDmeOnly.Should().Be(expectedIsDme);
        ilsVorRecord.Flags.IsBackCourse.Should().Be(expectedIsBackCourse);
        ilsVorRecord.Flags.HasGlideslope.Should().Be(expectedHasGlideslope);
        ilsVorRecord.Flags.IsDmePresent.Should().Be(expectedIsDmePresent);
        ilsVorRecord.Flags.NavTrue.Should().Be(expectedNavTrue);
    }

    [Theory]
    [InlineData("ITST", 203221094, 145101147, 67665, 3.00, 37049.477)]
    public void ILS_VOR_Record_Glideslope_Parsed(
        string ilsIdentifier,
        int longitude,
        int latitude,
        int elevation,
        float expectedPitch,
        float expectedRange)
    {
        var glideSlopeRecord = GetBglFile(FileName)
            .GetIlsVorRecord(ilsIdentifier)
            .GetRecordType<GlideslopeRecord>();
        
        glideSlopeRecord.Should().NotBeNull();

        glideSlopeRecord.Coordinates.Should().Be(Coordinate.FromBgl(longitude, latitude, elevation));
        glideSlopeRecord.Pitch.Should().Be(expectedPitch);
        glideSlopeRecord.Range.Should().Be(expectedRange);
    }

    [Theory]
    [InlineData("ITST", 18, RunwayDesignator.None, 179.580000, 5.00)]
    public void ILS_VOR_Record_Localizer_Parsed(
        string ilsIdentifier,
        byte expectedRunwayNumber,
        RunwayDesignator expectedRunwayDesignator,
        float expectedHeading,
        float expectedBeamWidth)
    {
        var localizerRecord = GetBglFile(FileName)
            .GetIlsVorRecord(ilsIdentifier)
            .GetRecordType<LocalizerRecord>();
        
        localizerRecord.Should().NotBeNull();
        
        localizerRecord.RunwayNumber.Should().Be(expectedRunwayNumber);
        localizerRecord.Designator.Should().Be(expectedRunwayDesignator);
        localizerRecord.Heading.Should().BeApproximately(expectedHeading, .000005f);
        localizerRecord.BeamWidthDegrees.Should().Be(expectedBeamWidth);
    }

    [Theory]
    [InlineData("ITST", "Testfield Regional ILS RWY 18")]
    public void ILS_VOR_Record_Name_Parsed(string ilsIdentifier, string expectedName)
    {
        var nameRecord = GetBglFile(FileName)
            .GetIlsVorRecord(ilsIdentifier)
            .GetRecordType<NameRecord>();
        
        nameRecord.Should().NotBeNull();
        
        nameRecord.Name.Should().Be(expectedName);
    }
}