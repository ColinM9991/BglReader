namespace BglReader;

public struct Coordinate(
    int latitude,
    int longitude)
{
    public Coordinate(
        int latitude,
        int longitude,
        int elevation) : this(latitude, longitude)
    {
        Elevation = elevation / 1000f;
    }

    public double Latitude { get; } = 90.0f - latitude * (180.0f / (2f * 0x10000000));

    public double Longitude { get; } = longitude * (360.0f / (3f * 0x10000000)) - 180.0f;

    public float? Elevation { get; } = null;
}