namespace BglReader;

public readonly record struct Elevation(double Value)
{
    public double Value { get; } = Value;

    internal static Elevation FromBgl(int value) => new(value / 1000f);
}