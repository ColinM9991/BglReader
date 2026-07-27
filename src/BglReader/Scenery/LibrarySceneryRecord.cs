namespace BglReader.Scenery;

public class LibrarySceneryRecord : LibrarySceneryRecordBase
{
    public LibrarySceneryRecord(BglBinaryReader reader, bool shouldRewindStream = true) : base(reader, shouldRewindStream)
    {
        Name = new Guid(reader.ReadBytes(16));
        Scale = reader.ReadSingle();
        
        // TODO Map attached record
    }

    public Guid Name { get; }
    
    public float Scale { get; }
}