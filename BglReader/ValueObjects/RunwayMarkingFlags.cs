using BglReader.Attributes;

namespace BglReader.ValueObjects;

[BitField(typeof(ushort))]
public partial class RunwayMarkingFlags
{
    [Bits(0)] public partial bool Edges { get; }

    [Bits(1)] public partial bool Threshold { get; }

    [Bits(2)] public partial bool FixedDistance { get; }

    [Bits(3)] public partial bool Touchdown { get; }

    [Bits(4)] public partial bool Dashes { get; }

    [Bits(5)] public partial bool Ident { get; }

    [Bits(6)] public partial bool Precision { get; }

    [Bits(7)] public partial bool EdgePavement { get; }

    [Bits(8)] public partial bool SingleEnd { get; }

    [Bits(9)] public partial bool PrimaryClosed { get; }

    [Bits(10)] public partial bool SecondaryClosed { get; }

    [Bits(11)] public partial bool PrimaryStol { get; }

    [Bits(12)] public partial bool SecondaryStol { get; }

    [Bits(13)] public partial bool AlternateThreshold { get; }

    [Bits(14)] public partial bool AlternateFixedDistance { get; }

    [Bits(15)] public partial bool AlternateTouchdown { get; }
}