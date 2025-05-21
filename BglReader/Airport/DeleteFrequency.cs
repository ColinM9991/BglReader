namespace BglReader.Airport;

public readonly struct DeleteFrequency(uint info)
{
    public uint Type { get; } = (info >> 28) & 0xF;

    public uint Frequency { get; } = (info & 0xFFFFFFF) / 1000;
}