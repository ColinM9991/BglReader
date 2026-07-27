namespace BglReader.Airport.Subsections.Taxi;

public enum TaxiPointType : byte
{
    Normal = 1,
    HoldShort = 2,
    IlsHoldShort = 4,
    HoldShortNoDraw = 5,
    IlsHoldShortNoDraw = 6
}