namespace BglReader;

public readonly record struct Longitude(double Value)
{
    public double Value { get; } = Value;

    internal static Longitude FromDword(int dword) => new(dword * (360.0 / 0x30000000) - 180.0);

    internal static Longitude FromBglOffset(double longitude, Latitude latitude, double offset) => new(longitude +
        offset * 360.0 /
        (40075000.0 *
         Math.Cos(Math.PI / 180.0 *
                  Math.Abs(latitude.Value / 2.0))));
}