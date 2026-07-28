using BglReader.Generic;

namespace BglReader.Airport.Subsections;

public class TowerSceneryObjectRecord : BglRecord
{
    public TowerSceneryObjectRecord(ushort id, BglBinaryReader reader) : base(id, reader)
    {
        ScenerySize = reader.ReadUInt32();
        EmbeddedObject = reader.ReadBytes((int)ScenerySize);
    }

    public uint ScenerySize { get; }

    public byte[] EmbeddedObject { get; }
}