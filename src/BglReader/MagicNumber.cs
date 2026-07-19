namespace BglReader;

public struct MagicNumber(
    byte[] partOne,
    byte[] partTwo)
{
    public byte[] PartOne { get; } = partOne;

    public byte[] PartTwo { get; } = partTwo;
}