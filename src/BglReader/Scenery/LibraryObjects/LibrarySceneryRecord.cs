namespace BglReader.Scenery.LibraryObjects;

[BinarySerializable]
public partial class LibrarySceneryRecord : LibrarySceneryRecordBase
{
    [Binary(1)]
    [BinaryReader(typeof(GuidValueReader))]
    public Guid Name { get; }
    
    [Binary(2)]
    public float Scale { get; }
    // TODO Map attached record
}