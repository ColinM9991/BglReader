using BglReader.Navigation;

namespace BglReader.ValueObjects.BitFields;

[BitField(typeof(ushort))]
public partial class GeoPolFlags
{
    [Bits(0, 14)]
    public partial int NumberOfVertices { get; }
    
    [Bits(14, 2)]
    public partial GeoPolType Type { get; }
}