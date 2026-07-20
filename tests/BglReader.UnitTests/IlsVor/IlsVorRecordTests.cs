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

        ilsVorRecord.ShouldNotBeNull();
        ilsVorRecord.Type.ShouldBe(expectedData.Type);
        ilsVorRecord.Coordinates.Longitude.ShouldBe(expectedData.Coordinates.Longitude);
        ilsVorRecord.Coordinates.Latitude.ShouldBe(expectedData.Coordinates.Latitude);
        ilsVorRecord.Coordinates.Elevation!.Value.Value.ShouldBe(expectedData.Coordinates.Elevation!.Value.Value, 0.0001f);
        ilsVorRecord.Frequency.ShouldBeEquivalentTo(expectedData.Frequency);
        ilsVorRecord.Range.ShouldBe(expectedData.Range);
        ilsVorRecord.MagneticVariation.ShouldBe(expectedData.MagneticVariation);
        ilsVorRecord.RegionFlags.Identifier.ToString().ShouldBe(expectedData.RegionIdentifier);
        ilsVorRecord.Flags.IsNotDmeOnly.ShouldBe(expectedData.IsDme);
        ilsVorRecord.Flags.IsBackCourse.ShouldBe(expectedData.IsBackCourse);
        ilsVorRecord.Flags.HasGlideslope.ShouldBe(expectedData.HasGlideslope);
        ilsVorRecord.Flags.IsDmePresent.ShouldBe(expectedData.IsDmePresent);
        ilsVorRecord.Flags.NavTrue.ShouldBe(expectedData.NavTrue);
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
        
        glideSlopeRecord.ShouldNotBeNull();

        glideSlopeRecord.Coordinates.Longitude.ShouldBe(expectedData.Coordinates.Longitude);
        glideSlopeRecord.Coordinates.Latitude.ShouldBe(expectedData.Coordinates.Latitude);
        glideSlopeRecord.Coordinates.Elevation!.Value.Value.ShouldBe(expectedData.Coordinates.Elevation!.Value.Value, 0.0001f);
        glideSlopeRecord.Pitch.ShouldBe(expectedData.Pitch);
        glideSlopeRecord.Range.ShouldBe(expectedData.Range);
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
        
        localizerRecord.ShouldNotBeNull();
        
        localizerRecord.RunwayNumber.ShouldBe(expectedData.RunwayNumber);
        localizerRecord.Designator.ShouldBe(expectedData.Designator);
        localizerRecord.Heading.ShouldBe(expectedData.Heading, .000005f);
        localizerRecord.BeamWidthDegrees.ShouldBe(expectedData.BeamWidth);
    }

    [Theory]
    [InlineData("ITST", "Testfield Regional ILS RWY 18")]
    public void ILS_VOR_Record_Name_Parsed(string ilsIdentifier, string expectedName)
    {
        var nameRecord = GetBglFile(FileName)
            .GetIlsVorRecord(ilsIdentifier)
            .GetRecordType<NameRecord>();
        
        nameRecord.ShouldNotBeNull();
        
        nameRecord.Name.ShouldBe(expectedName);
    }
}