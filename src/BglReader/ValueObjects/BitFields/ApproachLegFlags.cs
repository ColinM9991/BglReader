using BglReader.Airport.Subsections.Types;
using BglReader.Attributes;

namespace BglReader.ValueObjects.BitFields;

[BitField(typeof(ushort))]
public partial class ApproachLegFlags
{
    [Bits(0, 2)]
    public partial TurnDirection TurnDirection { get; }

    [Bits(8)]
    public partial bool IsTrueCourse { get; }

    [Bits(9)]
    public partial bool IsTimeBased { get; }

    [Bits(10)]
    public partial bool IsFlyover { get; }
}