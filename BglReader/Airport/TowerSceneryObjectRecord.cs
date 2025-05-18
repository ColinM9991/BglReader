namespace BglReader.Airport;

public class TowerSceneryObjectRecord : BglRecord
{
    public TowerSceneryObjectRecord(BinaryReader reader) : base(reader)
    {
        ScenerySize = reader.ReadUInt32();
        SceneryObject = reader.ReadBytes((int)ScenerySize);
    }

    public uint ScenerySize { get; set; }

    public byte[] SceneryObject { get; set; }
}