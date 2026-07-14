namespace BglReader.ValueObjects;

public readonly struct BglInvertedBool(bool value)
{
    private readonly bool _value = value;
    
    public static explicit operator BglInvertedBool(int value) => new(value == 0);

    public static implicit operator bool(BglInvertedBool bglInvertedBool) => bglInvertedBool._value;

    public override string ToString() => _value.ToString();
}