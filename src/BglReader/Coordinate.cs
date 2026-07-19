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
        Elevation = elevation.Value;
    }

    public double Latitude { get; } = latitude.Value;

    public double Longitude { get; } = longitude.Value;

    public float? Elevation { get; } = null;
    
    public static Coordinate FromBgl(int longitude, int latitude) => new(BglReader.Longitude.FromDword(longitude), BglReader.Latitude.FromDword(latitude));
    
    public static Coordinate FromBgl(int longitude, int latitude, int elevation) => new(BglReader.Longitude.FromDword(longitude), BglReader.Latitude.FromDword(latitude), BglReader.Elevation.FromBgl(elevation));

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