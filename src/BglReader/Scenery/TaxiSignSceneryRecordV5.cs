namespace BglReader.Scenery;

public sealed class TaxiSignSceneryRecordV5 : TaxiSignSceneryRecordBase
{

    public TaxiSignSceneryRecordV5(BglBinaryReader reader) : base(reader)
    {
        CreateSigns(reader);
    }
}