namespace BglReader;

public readonly struct Coordinate(
    Longitude longitude,
    Latitude latitude) : IEquatable<Coordinate>
{
    public Coordinate(
        Longitude longitude,
        Latitude latitude,
        Elevation elevation) : this(longitude, latitude)
    {
        Elevation = elevation;
    }

    public Latitude Latitude { get; } = latitude;

    public Longitude Longitude { get; } = longitude;

    public Elevation? Elevation { get; } = null;
    
    internal static Coordinate FromBgl(int longitude, int latitude) => new(Longitude.FromDword(longitude), Latitude.FromDword(latitude));
    
    internal static Coordinate FromBgl(int longitude, int latitude, int elevation) => new(Longitude.FromDword(longitude), Latitude.FromDword(latitude), BglReader.Elevation.FromBgl(elevation));

    public bool Equals(Coordinate other)
    {
        return Latitude.Equals(other.Latitude) && Longitude.Equals(other.Longitude) && Nullable.Equals(Elevation, other.Elevation);
    }

    public override bool Equals(object? obj)
    {
        return obj is Coordinate other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Latitude, Longitude, Elevation);
    }
}