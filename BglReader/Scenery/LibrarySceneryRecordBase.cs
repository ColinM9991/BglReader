using BglReader.Generic;

namespace BglReader.Scenery;

public abstract class LibrarySceneryRecordBase : SceneryBglRecord
{
    protected LibrarySceneryRecordBase(BinaryReader reader) : base(reader)
    {
        Coordinates = new Coordinate(reader.ReadInt32(), reader.ReadInt32(), reader.ReadInt32());

        Flags = (LibraryObjectFlags)reader.ReadUInt16();
        Pitch = reader.ReadUInt16();
        Bank = reader.ReadUInt16();
        Heading = reader.ReadUInt16();
        ImageComplexity = (ImageComplexity)reader.ReadUInt16();
        Unknown = reader.ReadBytes(2);
        Instance = new Guid(reader.ReadBytes(16));
    }
    
    public Coordinate Coordinates { get; }
    
    public LibraryObjectFlags Flags { get; }
    
    public double Pitch { get; }
    
    public double Bank { get; }
    
    public double Heading { get; }
    
    public ImageComplexity ImageComplexity { get; }
    
    public byte[] Unknown { get; }
    
    public Guid Instance { get; }
}