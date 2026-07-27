namespace BglReader.Scenery.TaxiSigns;

public sealed class TaxiSignSceneryRecordV5 : TaxiSignSceneryRecordBase
{
    public TaxiSignSceneryRecordV5(ushort id, BglBinaryReader reader) : base(id, reader)
    {
        CreateSigns(reader);
    }
}