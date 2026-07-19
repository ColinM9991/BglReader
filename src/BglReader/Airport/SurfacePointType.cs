namespace BglReader.Airport;

public enum SurfacePointType : byte
{
    Taxi = 0x1,
    Runway = 0x2,
    Parking = 0x3,
    Path = 0x4,
    Closed = 0x5,
    Vehicle = 0x6
}