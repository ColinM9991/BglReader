using BglReader.Generic;

namespace BglReader.Scenery.LibraryObjects;

public abstract class IncludedSceneryObject : BglRecord
{
    public IncludedSceneryObject(ushort id, BglBinaryReader reader) : base(id, reader)
    {
        ScenerySize = reader.ReadUInt32();
        EmbeddedObject = SceneryBglRecord.Read(reader);

        _ = reader.ReadBytes(2); // Padding for scenery objects
    }

    public uint ScenerySize { get; }

    public SceneryBglRecord? EmbeddedObject { get; }
}