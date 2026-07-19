namespace BglReader.Airport.Taxi;

public readonly struct TaxiWayPoint(
    TaxiPointType type,
    TaxiPointFlag flag,
    Coordinate coordinate)
{
    public TaxiPointType Type { get; } = type;

    public TaxiPointFlag Flag { get; } = flag;

    public Coordinate Coordinate { get; } = coordinate;
}