using BglReader.Airport.Subsections.Types;

namespace BglReader.ValueObjects.BitFields;

[BitField(typeof(byte))]
public partial class SurfacePointFlags
{
    [Bits(0, 5)]
    public partial SurfacePointType Type { get; }

    [Bits(5, 2)]
    public partial SurfaceFlags SurfaceFlags { get; }

    [Bits(7)]
    public partial bool Reserved { get; }
}