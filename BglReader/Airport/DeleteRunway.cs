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

    public int PrimaryRunwayDesignator { get; } = runwayDesignator & 0xF; // Todo runway designator?

    public int SecondaryRunwayDesignator { get; } = (runwayDesignator >> 4) & 0xF; // TODO runway designator?
}