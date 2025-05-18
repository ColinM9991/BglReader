namespace BglReader;

public class BglRecord
{
    protected BglRecord(
        BinaryReader reader)
    {
        Size = reader.ReadUInt32();
    }

    public uint Size { get; set; }
}