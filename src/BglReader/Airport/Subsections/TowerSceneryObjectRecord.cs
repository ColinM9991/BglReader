using BglReader.Generic;

namespace BglReader.Airport.Subsections;

[BinarySerializable]
public partial class TowerSceneryObjectRecord : BglRecord
{
    [Binary(1)]
    public int ScenerySize { get; }

    [Binary(2)]
    [BinaryConsume(nameof(ScenerySize))]
    public byte[] EmbeddedObject { get; }
}