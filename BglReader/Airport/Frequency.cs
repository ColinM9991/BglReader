namespace BglReader.Airport;

public readonly struct Frequency
{
    private readonly uint _frequency;

    private Frequency(uint frequency)
    {
        _frequency = frequency / 1000;
    }

    public uint Value => _frequency;

    public override string ToString() => $"{_frequency / 1000}.{_frequency % 1000:000}";

    public static explicit operator Frequency(uint value) => new(value);

    public static explicit operator Frequency(int value)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(value, 0);
        return new Frequency((uint)value);
    }
}