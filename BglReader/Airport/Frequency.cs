namespace BglReader.Airport;

public readonly struct Frequency : IEquatable<Frequency>
{
    private Frequency(uint frequency)
    {
        Value = frequency / 1000;
    }

    public uint Value { get; }

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