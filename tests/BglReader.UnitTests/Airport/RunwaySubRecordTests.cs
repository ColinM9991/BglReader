using BglReader.Airport;
using BglReader.ValueObjects;

namespace BglReader.UnitTests;

public class RunwaySubRecordTests : TestBase
{
    [Theory]
    [InlineData(
        AirportRecordDataType.OffsetPrimary,
        AirportSubReportBaseRecord.SubReportBaseType.OffsetThreshold,
        SurfaceType.Concrete,
        76.2f,
        30.48f)]
    [InlineData(
        AirportRecordDataType.BlastPadSecondary,
        AirportSubReportBaseRecord.SubReportBaseType.BlastPad,
        SurfaceType.Gravel,
        60.96f,
        36.576f)]
    [InlineData(
        AirportRecordDataType.OverrunSecondary,
        AirportSubReportBaseRecord.SubReportBaseType.Overrun,
        SurfaceType.Dirt,
        91.44f,
        27.432f)]
    public void RunwaySubRecord_Offset_Parsed(
        AirportRecordDataType type,
        AirportSubReportBaseRecord.SubReportBaseType expectedSubReportType,
        SurfaceType expectedSurfaceType,
        float expectedLength,
        float expectedWidth)
    {
        const string airportName = "KTST";
        const byte runwayNumber = 18;
        
        var offset = GetBglFile(FileName)
            .GetAirport(airportName)
            .GetRunway(runwayNumber)
            .GetSubRecordByType(type);

        offset.ShouldNotBeNull();

        offset.Type.ShouldBe(expectedSubReportType);
        offset.SurfaceType.ShouldBe(expectedSurfaceType);
        offset.Length.ShouldBe(expectedLength);
        offset.Width.ShouldBe(expectedWidth);
    }

    [Theory]
    [InlineData(
        AirportRecordDataType.ApproachLightsPrimary,
        ApproachLightSystem.ALSF2,
        11,
        true,
        true,
        true)]
    [InlineData(
        AirportRecordDataType.ApproachLightsSecondary,
        ApproachLightSystem.MALSR,
        5,
        false,
        false,
        true)]
    public void RunwaySubRecord_ApproachLights_Parsed(
        AirportRecordDataType type,
        ApproachLightSystem expectedSystem,
        int expectedStrobes,
        bool expectedReil,
        bool expectedTouchdown,
        bool expectedEndLights)
    {
        const string airportName = "KTST";
        const byte runwayNumber = 18;
        var approachLights = GetBglFile(FileName)
            .GetAirport(airportName)
            .GetRunway(runwayNumber)
            .GetSubRecordByType<AirportApproachLightsSubRecord>(type);

        approachLights.ShouldNotBeNull();

        approachLights.NumberOfStrobes.ShouldBe((byte)expectedStrobes);
        approachLights.Flags.System.ShouldBe(expectedSystem);
        approachLights.Flags.Reil.ShouldBe(expectedReil);
        approachLights.Flags.Touchdown.ShouldBe(expectedTouchdown);
        approachLights.Flags.EndLights.ShouldBe(expectedEndLights);
    }

    [Theory]
    [InlineData(
        AirportRecordDataType.VasiLeftPrimary,
        VasiType.Papi4,
        15.24,
        304.8,
        13.716,
        3.00)]
    [InlineData(
        AirportRecordDataType.VasiRightSecondary,
        VasiType.Vasi21,
        13.716,
        304.8,
        9.144,
        3.10)]
    public void RunwaySubRecord_Vasi_Parsed(
        AirportRecordDataType type,
        VasiType expectedVasiType,
        float expectedBiasX,
        float expectedBiasZ,
        float expectedSpacing,
        float expectedPitch)
    {
        const string airportName = "KTST";
        const byte runwayNumber = 18;
        var approachLights = GetBglFile(FileName)
            .GetAirport(airportName)
            .GetRunway(runwayNumber)
            .GetSubRecordByType<AirportVasiSubRecord>(type);

        approachLights.ShouldNotBeNull();

        approachLights.Type.ShouldBe(expectedVasiType);
        approachLights.BiasX.ShouldBe(expectedBiasX);
        approachLights.BiasZ.ShouldBe(expectedBiasZ);
        approachLights.Spacing.ShouldBe(expectedSpacing);
        approachLights.Pitch.ShouldBe(expectedPitch);
    }
}