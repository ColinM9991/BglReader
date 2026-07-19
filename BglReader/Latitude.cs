namespace BglReader;

public readonly record struct Latitude(double Value)
{
    public double Value { get; } = Value;

    internal static Latitude FromDword(int dword) => new(90.0 - dword * (180.0 / 0x20000000));

    internal static Latitude FromBglOffset(double latitude, double offset) => new(latitude +
        offset * 360.0 / 40007000.0);
}