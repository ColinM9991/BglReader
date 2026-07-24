namespace BglReader.Scenery;

public sealed class TaxiSignSceneryRecordV6 : TaxiSignSceneryRecordBase
{
    public TaxiSignSceneryRecordV6(BglBinaryReader reader) : base(reader)
    {
        UnknownV6 = reader.ReadBytes(32);
        CreateSigns(reader);
    }

    public byte[] UnknownV6 { get; }
}