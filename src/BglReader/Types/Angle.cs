namespace BglReader.Types;

public readonly struct Angle
{
    public Angle(uint value)
    {
        Value = ((double)value * 360) / 65535;
    }

    public double Value { get; }

    public override string ToString() => $"{Value:000.000}";
}