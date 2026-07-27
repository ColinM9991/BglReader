namespace BglReader.Scenery.LibraryObjects;

public class LibrarySceneryRecord : LibrarySceneryRecordBase
{
    public LibrarySceneryRecord(ushort id, BglBinaryReader reader) : base(id, reader)
    {
        Name = new Guid(reader.ReadBytes(16));
        Scale = reader.ReadSingle();
        
        // TODO Map attached record
    }

    public Guid Name { get; }
    
    public float Scale { get; }
}