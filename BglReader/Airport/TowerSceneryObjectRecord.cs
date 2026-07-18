using BglReader.Generic;

namespace BglReader.Airport;

public class TowerSceneryObjectRecord : BglRecord
{
    public TowerSceneryObjectRecord(BglBinaryReader reader) : base(reader)
    {
        ScenerySize = reader.ReadUInt32();
        SceneryObject = reader.ReadBytes((int)ScenerySize);
    }

    public uint ScenerySize { get; }

    public byte[] SceneryObject { get; }
}