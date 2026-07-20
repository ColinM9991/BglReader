namespace BglReader;

public readonly record struct Longitude(double Value)
{
    private const double Scale = 360.0 / 0x30000000;
    public double Value { get; } = Value;

    private static int ToDword(double longitude) => (int)Math.Round((longitude + 180.0) / Scale);
    
    public static Longitude FromDword(int dword) => new(dword * Scale - 180.0);
    
    public static Longitude Quantized(double longitude, Latitude latitude, double offset) =>
        Quantized(FromBglOffset(longitude, latitude, offset).Value);

    public static Longitude Quantized(double longitude) => FromDword(ToDword(longitude));

    private static Longitude FromBglOffset(double longitude, Latitude latitude, double offset) => new(longitude +
        offset * 360.0 /
        (40075000.0 *
         Math.Cos(Math.PI / 180.0 *
                  Math.Abs(latitude.Value))));
}