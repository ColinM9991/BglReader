using BglReader.Navigation;
using BglReader.Types;

namespace BglReader.ValueObjects.BitFields;

[BitField(typeof(uint))]
public partial class WaypointSegmentFlags
{
    [Bits(0, 3)]
    public partial WaypointSegmentType Type { get; }
    
    [Bits(5, 27)]
    public partial IcaoIdentifier Identifier { get; }
}