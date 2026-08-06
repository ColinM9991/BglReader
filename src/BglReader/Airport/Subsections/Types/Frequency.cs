namespace BglReader.Airport.Subsections.Types;

public readonly struct Frequency(uint frequency) : IEquatable<Frequency>
{
    public uint Value { get; } = frequency / 1000;

    public override string ToString() => $"{Value / 1000}.{Value % 1000:000}";

    public static explicit operator Frequency(uint value) => new(value);

    public static explicit operator Frequency(int value)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(value, 0);
        return new Frequency((uint)value);
    }

    public bool Equals(Frequency other)
    {
        return Value == other.Value;
    }

    public override bool Equals(object? obj)
    {
        return obj is Frequency other && Equals(other);
    }

    public override int GetHashCode()
    {
        return (int)Value;
    }
}