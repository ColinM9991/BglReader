namespace BglReader;

public readonly record struct Latitude(double Value)
{
    private const double Scale = 180.0 / 0x20000000;
    
    public double Value { get; } = Value;
    
    private static int ToDword(double latitude) => (int)Math.Round((90.0 - latitude) / Scale);

    public static Latitude FromDword(int dword) => new(90.0 - dword * Scale);

    private static Latitude FromBglOffset(double latitude, double offset) => new(latitude +
        offset * 360.0 / 40007000.0);
    
    public static Latitude Quantized(double latitude) => FromDword(ToDword(latitude));
    
    public static Latitude Quantized(Latitude latitude, double offset) =>
        Quantized(FromBglOffset(latitude.Value, offset).Value);
}