namespace BglReader;

public readonly record struct Longitude(double Value)
{
    public double Value { get; } = Value;
    
    internal static Longitude FromDword(int dword) => new(dword * (360.0 / 0x30000000) - 180.0);
}