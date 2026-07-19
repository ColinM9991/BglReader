using BglReader.Attributes;

namespace BglReader.ValueObjects;

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

public enum ApproachLightSystem : byte
{
    None = 0x00,
    ODALS = 0x01,
    MALSF = 0x02,
    MALSR = 0x03,
    SSALF = 0x04,
    SSALR = 0x05,
    ALSF1 = 0x06,
    ALSF2 = 0x07,
    RAIL = 0x08,
    CALVERT = 0x09,
    CALVERT2 = 0x0A,
    MALS = 0x0B,
    SALS = 0x0C,
    SALSF = 0x0D,
    SSALS = 0x0E
}