namespace BglReader;

public readonly record struct Elevation(float Value)
{
    public float Value { get; } = Value;

    internal static Elevation FromBgl(int value) => new(value / 1000f);
}