namespace BglReader.Airport;

public readonly struct Triangle(
    float distanceBetweenPoints,
    ushort startIndex,
    ushort endIndex)
{
    public float DistanceBetweenPoints { get; } = distanceBetweenPoints;

    public ushort StartIndex { get; } = startIndex;

    public ushort EndIndex { get; } = endIndex;
}