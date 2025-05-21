namespace BglReader.Airport;

public enum WaypointType : byte
{
    Named = 1,
    Unnamed = 2,
    VOR = 3,
    NDB = 4,
    OffRoute = 5,
    IAF = 6,
    FAF = 7
}