using BglReader.Airport;
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
        "KTST")]
    public void ILS_VOR_Record_Parsed(
        string identifier,
        IlsVorType expectedType,
        int longitude,
        int latitude,
        int elevation,
        uint expectedFrequency,
        float expectedRange,
        MagneticVariation expectedMagneticVariation,
        string expectedRegionIdentifier)
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
    }
}