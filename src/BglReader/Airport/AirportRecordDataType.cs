namespace BglReader.Airport;

public enum AirportRecordDataType : ushort
{
    OffsetPrimary = 0x0005,
    OffsetSecondary = 0x0006,
    BlastPadPrimary = 0x0007,
    BlastPadSecondary = 0x0008,
    OverrunPrimary = 0x0009,
    OverrunSecondary = 0x000A,
    VasiLeftPrimary = 0x000B,
    VasiRightPrimary = 0x000C,
    VasiLeftSecondary = 0x000D,
    VasiRightSecondary = 0x000E,
    ApproachLightsPrimary = 0x000F,
    ApproachLightsSecondary = 0x0010,
    MarkingBias = 0x0065
}