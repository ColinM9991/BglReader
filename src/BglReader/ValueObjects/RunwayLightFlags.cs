using BglReader.Attributes;

namespace BglReader.ValueObjects;

[BitField(typeof(byte))]
public partial class RunwayLightFlags
{
    [Bits(0, 2)] public partial RunwayLightIntensity Edge { get; }

    [Bits(2, 2)] public partial RunwayLightIntensity Center { get; }

    [Bits(4)] public partial bool CenterRed { get; }

    [Bits(5)] public partial bool AlternatePrecision { get; }

    [Bits(6)] public partial bool LeadingZeroIdent { get; }

    [Bits(7)] public partial bool NoThresholdEndArrows { get; }
}