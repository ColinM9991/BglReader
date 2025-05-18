namespace BglReader.Airport;

public readonly struct ApronTriangle(
    ushort firstIndex,
    ushort secondIndex,
    ushort thirdIndex)
{
    public ushort FirstIndex { get; } = firstIndex;

    public ushort SecondIndex { get; } = secondIndex;

    public ushort ThirdIndex { get; } = thirdIndex;
}