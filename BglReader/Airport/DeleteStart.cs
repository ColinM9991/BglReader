namespace BglReader.Airport;

public readonly struct DeleteStart(
    byte runwayNumber,
    byte runwayDesignator,
    byte type,
    byte unused)
{
    public byte RunwayNumber { get; } = runwayNumber;

    public RunwayDesignator RunwayDesignator { get; } = (RunwayDesignator)runwayDesignator;

    public StartType StartType { get; } = (StartType)type;
}