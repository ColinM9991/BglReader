namespace BglReader;

public struct MagicNumber(
    byte[] partOne,
    byte[] partTwo)
{
    public byte[] PartOne { get; set; } = partOne;

    public byte[] PartTwo { get; set; } = partTwo;
}