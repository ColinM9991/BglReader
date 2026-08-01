using BglReader.Generic;

namespace BglReader.Scenery.LibraryObjects;

[BinarySerializable]
public abstract partial class IncludedSceneryObject : BglRecord
{
    [Binary(1)]
    public uint ScenerySize { get; }

    [Binary(2)]
    [BinaryReader(typeof(SceneryReader))]
    public SceneryBglRecord? EmbeddedObject { get; }
    
    [Binary(3)]
    [BinaryDiscard(2)]
    public ICollection<byte> Padding { get; } 
}