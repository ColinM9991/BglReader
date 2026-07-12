using BglReader.Attributes;

namespace BglReader.ValueObjects;

[BitField(typeof(byte))]
public partial class RunwayPatternFlags
{
    [Bits(0)] public partial bool PrimaryTakeoff { get; }

    [Bits(1)] public partial bool PrimaryLanding { get; }

    [Bits(2)] public partial RunwayPatternDirection PrimaryPattern { get; }

    [Bits(3)] public partial bool SecondaryTakeoff { get; }

    [Bits(4)] public partial bool SecondaryLanding { get; }

    [Bits(5)] public partial RunwayPatternDirection SecondaryPattern { get; }

    [Bits(6)] public partial bool PrimaryMarkingBias { get; }

    [Bits(7)] public partial bool SecondaryMarkingBias { get; }
}