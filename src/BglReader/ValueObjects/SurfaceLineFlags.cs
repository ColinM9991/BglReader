using BglReader.Airport;
using BglReader.Attributes;

namespace BglReader.ValueObjects;

[BitField(typeof(byte))]
public partial class SurfaceLineFlags : IEquatable<SurfaceLineFlags>
{
    [Bits(0)]
    public partial bool CenterLine { get; }

    [Bits(1)]
    public partial bool CenterLineLighted { get; }

    [Bits(2, 2)]
    public partial EdgeMarkingType LeftEdge { get; }

    [Bits(4)]
    public partial bool LeftEdgeLighted { get; }

    [Bits(5, 2)]
    public partial EdgeMarkingType RightEdge { get; }

    [Bits(7)]
    public partial bool RightEdgeLighted { get; }

    public static SurfaceLineFlags From(
        bool centerLine,
        bool centerLineLighted,
        EdgeMarkingType leftEdge,
        bool leftEdgeLighted,
        EdgeMarkingType rightEdge,
        bool rightEdgeLighted)
    {
        var value = (byte)(
            (centerLine ? 1u : 0u) |
            (centerLineLighted ? 2u : 0u) |
            ((uint)leftEdge << 2) |
            (leftEdgeLighted ? 16u : 0u) |
            ((uint)rightEdge << 5) |
            (rightEdgeLighted ? 128u : 0u)
        );
        return new SurfaceLineFlags(value);
    }

    public bool Equals(SurfaceLineFlags? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return _value == other._value;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((SurfaceLineFlags)obj);
    }

    public override int GetHashCode()
    {
        return _value.GetHashCode();
    }
}