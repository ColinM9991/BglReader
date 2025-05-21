namespace BglReader.Airport;

public readonly struct DeleteStart(
    byte runwayNumber,
    byte runwayDesignator,
    byte type)
{
    public byte RunwayNumber { get; } = runwayNumber;

    public byte RunwayDesignator { get; } = runwayDesignator;

    public StartType StartType { get; } = (StartType)type;
}