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
        Elevation = elevation * 1000;
    }

    public double Latitude { get; set; } = 90.0 - latitude * (180.0 / (2 * 0x10000000));

    public double Longitude { get; set; } = longitude * (360.0 / (3 * 0x10000000)) - 180.0;

    public int? Elevation { get; set; } = null;
}