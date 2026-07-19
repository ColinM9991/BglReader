namespace BglReader.Airport;

public enum ApproachType
{
    GPS = 0x01,
    VOR = 0x02,
    NDB = 0x03,
    ILS = 0x04,
    LOCALIZER = 0x05,
    SDF = 0x06,
    LDA = 0x07,
    VORDME = 0x08,
    NDBDME = 0x09,
    RNAV = 0x0a,
    LOCALIZER_BACKCOURSE = 0x0b
}