using BglReader.Airport;
using BglReader.Airport.Taxi;
using BglReader.Attributes;

namespace BglReader.ValueObjects;

[BitField(typeof(uint))]
public partial class TaxiParkingFlags
{
    [Bits(0, 6)] public partial TaxiParkingName Name { get; }

    [Bits(6, 2)] public partial TurnDirection PushBack { get; }

    [Bits(8, 4)] public partial ParkingType ParkingType { get; }

    [Bits(12, 12)] public partial int Number { get; }

    [Bits(24, 8)] public partial int NumberOfAirlineCodes { get; }

    public static TaxiParkingFlags From(TaxiParkingName name, TurnDirection pushBackType, ParkingType type, int number,
        int numberOfAirlineCodes)
    {
        var val = (uint)name
                   | ((uint)pushBackType << 6)
                   | ((uint)type << 8)
                   | (uint)number << 12 
                   | (uint)numberOfAirlineCodes << 24;

        return new TaxiParkingFlags(val);
    }
}