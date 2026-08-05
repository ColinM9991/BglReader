using BglReader.Types;
using BglReader.ValueObjects.BitFields;

namespace BglReader.Airport.Subsections.Taxi;

[BinarySerializable]
public readonly partial record struct TaxiParking
{
    public TaxiParking(TaxiParkingFlags flags,
        float radius,
        float heading,
        float teeOffset,
        float teeOffset2,
        float teeOffset3,
        float teeOffset4,
        Coordinate coordinate,
        IEnumerable<string> airlineDesignators)
    {
        Flags = flags;
        Radius = radius;
        Heading = heading;
        TeeOffset = teeOffset;
        TeeOffset2 = teeOffset2;
        TeeOffset3 = teeOffset3;
        TeeOffset4 = teeOffset4;
        Coordinate = coordinate;
        AirlineDesignators = airlineDesignators.ToList();
    }

    [Binary(1)]
    public TaxiParkingFlags Flags { get; }
    
    private int NumberOfAirlineDesignators => Flags.NumberOfAirlineCodes;

    [Binary(2)]
    public float Radius { get; }

    [Binary(3)]
    public float Heading { get; }

    [Binary(4)]
    public float TeeOffset { get; }

    [Binary(5)]
    public float TeeOffset2 { get; }

    [Binary(6)]
    public float TeeOffset3 { get; }

    [Binary(7)]
    public float TeeOffset4 { get; }

    [Binary(8)]
    [BinaryReader(typeof(ThreeDimensionalCoordinateReader))]
    public Coordinate Coordinate { get; }

    [Binary(9)]
    [BinaryString(4)]
    [BinaryCollection(nameof(NumberOfAirlineDesignators))]
    public ICollection<string> AirlineDesignators { get; } = [];
}