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

    public uint LowDateTime { get; set; }

    public uint HighDateTime { get; set; }
}