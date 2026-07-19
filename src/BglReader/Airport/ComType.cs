namespace BglReader.Airport;

public enum ComType : ushort
{
    Atis = 0x0001,
    Multicom = 0x0002,
    Unicom = 0x0003,
    Ctaf = 0x0004,
    Ground = 0x0005,
    Tower = 0x0006,
    Clearance = 0x0007,
    Approach = 0x0008,
    Departure = 0x0009,
    Center = 0x000A,
    Fss = 0x000B,
    Awos = 0x000C,
    Asos = 0x000D,
    ClearancePreTaxi = 0x000E,
    RemoteClearanceDelivery = 0x000F
}