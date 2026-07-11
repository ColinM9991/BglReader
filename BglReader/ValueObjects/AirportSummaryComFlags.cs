using BglReader.Attributes;

namespace BglReader.ValueObjects;

[BitField(typeof(ushort))]
public partial class AirportSummaryComFlags
{
    [Bits(0)]
    public partial bool ComTowerAvailability { get; }
    
    [Bits(1, 2)]
    public partial RunwayAvailability RunwayAvailability { get; }
    
    [Bits(3, 2)]
    public partial int Unknown { get; }
    
    [Bits(5)]
    public partial bool IsGpsApproachAvailable { get; }

    [Bits(6)]
    public partial bool IsVorApproachAvailable { get; }

    [Bits(7)]
    public partial bool IsNdbApproachAvailable { get; }

    [Bits(8)]
    public partial bool IsIlsApproachAvailable { get; }

    [Bits(9)]
    public partial bool IsLocApproachAvailable { get; }

    [Bits(10)]
    public partial bool IsSdfApproachAvailable { get; }

    [Bits(11)]
    public partial bool IsLdaApproachAvailable { get; }

    [Bits(12)]
    public partial bool IsVorDmeApproachAvailable { get; }

    [Bits(13)]
    public partial bool IsNdbDmeApproachAvailable { get; }

    [Bits(14)]
    public partial bool IsRnavApproachAvailable { get; }

    [Bits(15)]
    public partial bool IsLocBcApproachAvailable { get; }
}