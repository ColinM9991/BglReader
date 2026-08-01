using BglReader.Generic;

namespace BglReader.Airport.Subsections;

[BinarySerializable]
public partial class TowerSceneryObjectRecord : BglRecord
{
    [Binary(1)]
    public int ScenerySize { get; }

    [Binary(2)]
    [BinaryCollection(nameof(ScenerySize))]
    public ICollection<byte> EmbeddedObject { get; }
}