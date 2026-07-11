using BglReader.Airport;
using BglReader.Attributes;

namespace BglReader.ValueObjects;

[BitField(typeof(byte))]
public partial class SurfaceLineFlags
{
    [Bits(0, 1)]
    public partial bool CenterLine { get; }

    [Bits(1, 1)]
    public partial bool CenterLineLighted { get; }

    [Bits(2, 2)]
    public partial EdgeMarkingType LeftEdge { get; }

    [Bits(4, 1)]
    public partial bool LeftEdgeLighted { get; }

    [Bits(5, 2)]
    public partial EdgeMarkingType RightEdge { get; }

    [Bits(7, 1)]
    public partial bool RightEdgeLighted { get; }
}