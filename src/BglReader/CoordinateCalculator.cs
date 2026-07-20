namespace BglReader;

public static class CoordinateCalculator
{
    public static Latitude OffsetLatitude(Latitude latitude, double offsetNorthMetres)
    {
        var metresPerDegree = MetersPerDegreeLatitude(latitude);

        return new Latitude(latitude.Value + offsetNorthMetres / metresPerDegree);
    }

    public static Longitude OffsetLongitude(
        Longitude longitude,
        Latitude latitude,
        double offsetEastMetres)
    {
        var metresPerDegree = MetersPerDegreeLongitude(latitude);

        return new Longitude(longitude.Value + offsetEastMetres / metresPerDegree);
    }

    private static double MetersPerDegreeLatitude(Latitude latitude)
    {
        var lat = DegreesToRadians(latitude);

        return 111132.92
               - 559.82 * Math.Cos(2 * lat)
               +   1.175 * Math.Cos(4 * lat)
               -   0.0023 * Math.Cos(6 * lat);
    }

    private static double MetersPerDegreeLongitude(Latitude latitude)
    {
        var lat = DegreesToRadians(latitude);

        return 111412.84 * Math.Cos(lat)
               -    93.5 * Math.Cos(3 * lat)
               +     0.118 * Math.Cos(5 * lat);
    }

    private static double DegreesToRadians(Latitude latitude)
        => latitude.Value * Math.PI / 180.0;
}