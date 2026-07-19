using BglReader.Airport;
using BglReader.Attributes;

namespace BglReader.ValueObjects;

[BitField(typeof(byte))]
public partial class SurfacePointFlags
{
    [Bits(0, 5)]
    public partial SurfacePointType Type { get; }

    [Bits(5)]
    public partial bool DrawSurface { get; }

    [Bits(6)]
    public partial bool DrawDetail { get; }

    [Bits(7)]
    public partial bool Reserved { get; }
}