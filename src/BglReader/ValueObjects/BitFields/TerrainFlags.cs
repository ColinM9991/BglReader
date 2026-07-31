using BglReader.Airport.Subsections.Taxi;
using BglReader.Airport.Subsections.Types;

namespace BglReader.ValueObjects.BitFields;

[BitField(typeof(byte))]
public partial class TerrainFlags
{
    [Bits(0, 2)]
    public partial Flatten Flatten { get; }
    
    [Bits(3, 2)]
    public partial SurfaceQuery SurfaceQuery { get; }
}