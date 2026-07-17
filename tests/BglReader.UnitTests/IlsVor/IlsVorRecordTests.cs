using BglReader.Generic;
using BglReader.Navigation;

namespace BglReader.UnitTests.IlsVor;

public class IlsVorRecordTests : TestBase
{
    [Theory]
    [MemberData(nameof(IlsVorTestData.IlsVorData), MemberType = typeof(IlsVorTestData))]
    public void ILS_VOR_Record_Parsed(
        string fileName,
        string identifier,
        ExpectedIlsVorData expectedData)
    {
        var ilsVorRecord = GetBglFile(fileName)
            .GetIlsVorRecord(identifier);

        ilsVorRecord.Should().NotBeNull();
        ilsVorRecord.Type.Should().Be(expectedData.Type);
        ilsVorRecord.Coordinates.Should().BeEquivalentTo(expectedData.Coordinates);
        ilsVorRecord.Frequency.Should().BeEquivalentTo(expectedData.Frequency);
        ilsVorRecord.Range.Should().Be(expectedData.Range);
        ilsVorRecord.MagneticVariation.Should().Be(expectedData.MagneticVariation);
        ilsVorRecord.RegionFlags.Identifier.ToString().Should().Be(expectedData.RegionIdentifier);
        ilsVorRecord.Flags.IsNotDmeOnly.Should().Be(expectedData.IsDme);
        ilsVorRecord.Flags.IsBackCourse.Should().Be(expectedData.IsBackCourse);
        ilsVorRecord.Flags.HasGlideslope.Should().Be(expectedData.HasGlideslope);
        ilsVorRecord.Flags.IsDmePresent.Should().Be(expectedData.IsDmePresent);
        ilsVorRecord.Flags.NavTrue.Should().Be(expectedData.NavTrue);
    }

    [Theory]
    [MemberData(nameof(IlsVorTestData.GlideSlopeData), MemberType = typeof(IlsVorTestData))]
    public void ILS_VOR_Record_Glideslope_Parsed(
        string fileName,
        string ilsIdentifier,
        ExpectedGlideSlopeData expectedData)
    {
        var glideSlopeRecord = GetBglFile(fileName)
            .GetIlsVorRecord(ilsIdentifier)
            .GetRecordType<GlideslopeRecord>();
        
        glideSlopeRecord.Should().NotBeNull();

        glideSlopeRecord.Coordinates.Should().Be(expectedData.Coordinates);
        glideSlopeRecord.Pitch.Should().Be(expectedData.Pitch);
        glideSlopeRecord.Range.Should().Be(expectedData.Range);
    }

    [Theory]
    [MemberData(nameof(IlsVorTestData.LocalizerData), MemberType = typeof(IlsVorTestData))]
    public void ILS_VOR_Record_Localizer_Parsed(
        string fileName,
        string ilsIdentifier,
        ExpectedLocalizerData expectedData)
    {
        var localizerRecord = GetBglFile(fileName)
            .GetIlsVorRecord(ilsIdentifier)
            .GetRecordType<LocalizerRecord>();
        
        localizerRecord.Should().NotBeNull();
        
        localizerRecord.RunwayNumber.Should().Be(expectedData.RunwayNumber);
        localizerRecord.Designator.Should().Be(expectedData.Designator);
        localizerRecord.Heading.Should().BeApproximately(expectedData.Heading, .000005f);
        localizerRecord.BeamWidthDegrees.Should().Be(expectedData.BeamWidth);
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