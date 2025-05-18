namespace BglReader.Airport;

public readonly struct TaxiPoint(
    byte type,
    byte flag,
    int longitude,
    int latitude)
{
    public TaxiPointType Type { get; } = (TaxiPointType)type;

    public TaxiPointFlag Flag { get; } = (TaxiPointFlag)flag;

    public Coordinate Coordinate { get; } = new(longitude, latitude);
}