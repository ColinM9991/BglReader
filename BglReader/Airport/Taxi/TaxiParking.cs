using System.Text;
using BglReader.ValueObjects;

namespace BglReader.Airport.Taxi;

public readonly record struct TaxiParking
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

    public TaxiParkingFlags Flags { get; }

    public float Radius { get; }

    public float Heading { get; }

    public float TeeOffset { get; }

    public float TeeOffset2 { get; }

    public float TeeOffset3 { get; }

    public float TeeOffset4 { get; }

    public Coordinate Coordinate { get; }

    public ICollection<string> AirlineDesignators { get; } = new List<string>();

    public static TaxiParking FromBgl(BinaryReader reader, AirportType airportType)
    {
        var flags = new TaxiParkingFlags(reader.ReadUInt32());
        var radius = reader.ReadSingle();
        var heading = reader.ReadSingle();
        var teeOffset = reader.ReadSingle();
        var teeOffset2 = reader.ReadSingle();
        var teeOffset3 = reader.ReadSingle();
        var teeOffset4 = reader.ReadSingle();
        var coordinate = airportType is AirportType.P3Dv5
            ? Coordinate.FromBgl(reader.ReadInt32(), reader.ReadInt32(), reader.ReadInt32())
            : Coordinate.FromBgl(reader.ReadInt32(), reader.ReadInt32());

        var airlineDesignators = Enumerable.Range(0, flags.NumberOfAirlineCodes)
            .Select(_ => Encoding.UTF8.GetString(reader.ReadBytes(4).TakeWhile(x => x != 0).ToArray()));

        return new TaxiParking(flags, radius, heading, teeOffset, teeOffset2, teeOffset3, teeOffset4, coordinate,
            airlineDesignators);
    }
}