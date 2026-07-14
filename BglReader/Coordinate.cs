namespace BglReader;

public struct Coordinate(
    int longitude,
    int latitude)
{
    public Coordinate(
        int longitude,
        int latitude,
        int elevation) : this(longitude, latitude)
    {
        Elevation = elevation / 1000f;
    }

    public double Latitude { get; } =
        90.0 - latitude * (180.0 / 0x20000000);

    public double Longitude { get; } =
        longitude * (360.0 / 0x30000000) - 180.0;

    public float? Elevation { get; } = null;
}