using BglReader.Attributes;

namespace BglReader.ValueObjects;

[BitField(typeof(ushort))]
public partial class AirportSummaryComFlags
{
    [Bits(0, 1)]
    public partial bool ComTowerAvailability { get; }
    
    [Bits(1, 2)]
    public partial RunwayAvailability RunwayAvailability { get; }
    
    [Bits(3, 2)]
    public partial int Unknown { get; }
    
    [Bits(5, 1)]
    public partial bool IsGpsApproachAvailable { get; }

    [Bits(6, 1)]
    public partial bool IsVorApproachAvailable { get; }

    [Bits(7, 1)]
    public partial bool IsNdbApproachAvailable { get; }

    [Bits(8, 1)]
    public partial bool IsIlsApproachAvailable { get; }

    [Bits(9, 1)]
    public partial bool IsLocApproachAvailable { get; }

    [Bits(10, 1)]
    public partial bool IsSdfApproachAvailable { get; }

    [Bits(11, 1)]
    public partial bool IsLdaApproachAvailable { get; }

    [Bits(12, 1)]
    public partial bool IsVorDmeApproachAvailable { get; }

    [Bits(13, 1)]
    public partial bool IsNdbDmeApproachAvailable { get; }

    [Bits(14, 1)]
    public partial bool IsRnavApproachAvailable { get; }

    [Bits(15, 1)]
    public partial bool IsLocBcApproachAvailable { get; }
}