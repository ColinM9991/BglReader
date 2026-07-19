namespace BglReader;

public struct BglDateTime
{
    public BglDateTime(
        uint lowDateTime,
        uint highDateTime)
    {
        LowDateTime = lowDateTime;
        HighDateTime = highDateTime;
    }

    public uint LowDateTime { get; }

    public uint HighDateTime { get; }
}