using BglReader.Airport.Taxi;
using BglReader.Attributes;

namespace BglReader.ValueObjects;

[BitField(typeof(byte))]
public partial class TaxiPathSurfaceFlags
{
    [Bits(0, 2)]
    public partial Flatten Flatten { get; }
    
    [Bits(3, 2)]
    public partial SurfaceQuery SurfaceQuery { get; }
}