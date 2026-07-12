using BglReader.Attributes;
using BglReader.Navigation;

namespace BglReader.ValueObjects;

[BitField(typeof(uint))]
public partial class WaypointSegmentFlags
{
    [Bits(0, 3)]
    public partial WaypointSegmentType Type { get; }
    
    [Bits(5, 27)]
    public partial uint Identifier { get; }
    
    public IcaoIdentifier IcaoIdentifier => IcaoIdentifier.Parse(Identifier, true);
}