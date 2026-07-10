using BglReader.Attributes;
using BglReader.Navigation;

namespace BglReader.ValueObjects;

[BitField(typeof(ushort))]
public partial class GeoPolFlags
{
    [Bits(0, 14)]
    public partial int NumberOfVertices { get; }
    
    [Bits(14, 2)]
    public partial GeoPolType Type { get; }
}