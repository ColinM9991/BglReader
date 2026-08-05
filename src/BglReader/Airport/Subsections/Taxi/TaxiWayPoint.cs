using BglReader.Types;

namespace BglReader.Airport.Subsections.Taxi;

[BinarySerializable]
public readonly partial struct TaxiWayPoint
{
    public TaxiWayPoint(
        TaxiPointType type,
        TaxiPointFlag flag,
        Coordinate coordinate)
    {
        Type = type;
        Flag = flag;
        Coordinate = coordinate;
    }
    
    [Binary(1)]
    public TaxiPointType Type { get; }

    [Binary(2)]
    public TaxiPointFlag Flag { get; }
    
    [Binary(3)]
    [BinaryConsume(2)]
    public byte[] Unknown { get; } = [];

    [Binary(4)]
    [BinaryReader(typeof(ThreeDimensionalCoordinateReader))]
    public Coordinate Coordinate { get; }
}