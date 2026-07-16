namespace BglReader;

public readonly struct Coordinate(
    Longitude longitude,
    Latitude latitude)
{
    public Coordinate(
        Longitude longitude,
        Latitude latitude,
        Elevation elevation) : this(longitude, latitude)
    {
        Elevation = elevation.Value;
    }

    public double Latitude { get; } = latitude.Value;

    public double Longitude { get; } = longitude.Value;

    public float? Elevation { get; } = null;
    
    public static Coordinate FromBgl(int longitude, int latitude) => new(BglReader.Longitude.FromDword(longitude), BglReader.Latitude.FromDword(latitude));
    
    public static Coordinate FromBgl(int longitude, int latitude, int elevation) => new(BglReader.Longitude.FromDword(longitude), BglReader.Latitude.FromDword(latitude), BglReader.Elevation.FromBgl(elevation));
}