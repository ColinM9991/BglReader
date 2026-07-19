namespace BglReader.ValueObjects;

public readonly record struct BglInvertedBool(bool Value)
{
    public static explicit operator BglInvertedBool(int value) => new(value == 0);
    
    public static explicit operator BglInvertedBool(uint value) => new(value == 0);

    public static implicit operator bool(BglInvertedBool bglInvertedBool) => bglInvertedBool.Value;

    public override string ToString() => Value.ToString();
}