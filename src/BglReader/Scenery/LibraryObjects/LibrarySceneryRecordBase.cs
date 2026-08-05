using BglReader.Types;

namespace BglReader.Scenery.LibraryObjects;

[BinarySerializable]
public abstract partial class LibrarySceneryRecordBase : SceneryBglRecord
{
    [Binary(1)]
    [BinaryReader(typeof(ThreeDimensionalCoordinateReader))]
    public Coordinate Coordinates { get; }
    
    [Binary(2)]
    public LibraryObjectFlags Flags { get; }
    
    [Binary(3)]
    [BinaryReader(typeof(AngleValueReader))]
    public Angle Pitch { get; }
    
    [Binary(4)]
    [BinaryReader(typeof(AngleValueReader))]
    public Angle Bank { get; }
    
    [Binary(5)]
    [BinaryReader(typeof(AngleValueReader))]
    public Angle Heading { get; }
    
    [Binary(6)]
    public ImageComplexity ImageComplexity { get; }
    
    [Binary(7)]
    [BinaryConsume(2)]
    public byte[] Unknown { get; }
    
    [Binary(8)]
    [BinaryReader(typeof(GuidValueReader))]
    public Guid Instance { get; }
}