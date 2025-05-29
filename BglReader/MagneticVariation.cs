using System.Globalization;

namespace BglReader;

public readonly struct MagneticVariation
{
    private readonly float _value;

    public MagneticVariation(float value)
    {
        _value = value > 180 ? value - 360 : value;
    }

    public static implicit operator float(MagneticVariation variation) => variation._value;
    
    public static explicit operator MagneticVariation(float value) => new MagneticVariation(value);

    public override string ToString() => _value.ToString(CultureInfo.InvariantCulture);
}