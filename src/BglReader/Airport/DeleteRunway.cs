using BglReader.Attributes;

namespace BglReader.Airport;

public readonly struct DeleteRunway(
    byte surface,
    byte runwayNumberPrimary,
    byte runwayNumberSecondary,
    byte runwayDesignator)
{
    public SurfaceType SurfaceType { get; } = (SurfaceType)surface;

    public byte PrimaryRunway { get; } = runwayNumberPrimary;

    public byte SecondaryRunway { get; } = runwayNumberSecondary;

    public DeleteRunwayFlags Flags { get; } = new(runwayDesignator);
}

[BitField(typeof(byte))]
public partial class DeleteRunwayFlags
{
    [Bits(0, 4)]
    public partial RunwayDesignator PrimaryRunwayDesignator { get; }
    
    [Bits(4, 4)]
    public partial RunwayDesignator SecondaryRunwayDesignator { get; }
}