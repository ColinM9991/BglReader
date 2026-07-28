using BglReader.Attributes;

namespace BglReader.ValueObjects.BitFields;

[BitField(typeof(byte))]
public partial class ApproachLightsFlags
{
    [Bits(0, 4)]
    public partial ApproachLightSystem System { get; }
    
    [Bits(5)]
    public partial bool EndLights { get; }
    
    [Bits(6)]
    public partial bool Reil { get; }
    
    [Bits(7)]
    public partial bool Touchdown { get; }
}