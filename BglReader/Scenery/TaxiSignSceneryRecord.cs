namespace BglReader.Scenery;

public class TaxiSignSceneryRecord : LibrarySceneryRecordBase
{
    public TaxiSignSceneryRecord(BinaryReader reader) : base(reader)
    {
        NumberOfSigns = reader.ReadUInt32();
        
        // TODO Map Signs
    }
    
    public uint NumberOfSigns { get; }
}