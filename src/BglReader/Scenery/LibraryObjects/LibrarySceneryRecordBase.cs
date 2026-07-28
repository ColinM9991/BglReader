using BglReader.Types;

namespace BglReader.Scenery.LibraryObjects;

public abstract class LibrarySceneryRecordBase : SceneryBglRecord
{
    protected LibrarySceneryRecordBase(ushort id, BglBinaryReader reader) : base(id, reader)
    {
        Coordinates = reader.ReadCoordinates();

        Flags = (LibraryObjectFlags)reader.ReadUInt16();
        Pitch = new Angle(reader.ReadUInt16());
        Bank = new Angle(reader.ReadUInt16());
        Heading = new Angle(reader.ReadUInt16());
        ImageComplexity = (ImageComplexity)reader.ReadUInt16();
        Unknown = reader.ReadBytes(2);
        Instance = new Guid(reader.ReadBytes(16));
    }
    
    public Coordinate Coordinates { get; }
    
    public LibraryObjectFlags Flags { get; }
    
    public Angle Pitch { get; }
    
    public Angle Bank { get; }
    
    public Angle Heading { get; }
    
    public ImageComplexity ImageComplexity { get; }
    
    public byte[] Unknown { get; }
    
    public Guid Instance { get; }
}