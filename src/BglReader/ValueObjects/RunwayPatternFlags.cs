using BglReader.Attributes;

namespace BglReader.ValueObjects;

[BitField(typeof(byte))]
public partial class RunwayPatternFlags
{
    [Bits(0)] public partial BglInvertedBool PrimaryTakeoff { get; }

    [Bits(1)] public partial BglInvertedBool PrimaryLanding { get; }

    [Bits(2)] public partial RunwayPatternDirection PrimaryPattern { get; }

    [Bits(3)] public partial BglInvertedBool SecondaryTakeoff { get; }

    [Bits(4)] public partial BglInvertedBool SecondaryLanding { get; }

    [Bits(5)] public partial RunwayPatternDirection SecondaryPattern { get; }

    [Bits(6)] public partial bool PrimaryMarkingBias { get; }

    [Bits(7)] public partial bool SecondaryMarkingBias { get; }
}