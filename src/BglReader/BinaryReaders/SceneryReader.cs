using BglReader.Scenery;

namespace BglReader.BinaryReaders;

public sealed class SceneryReader : IBinaryValueReader<SceneryBglRecord?>
{
    public static SceneryBglRecord? Read(BglBinaryReader reader)
    {
        var id = reader.ReadUInt16();

        return SceneryBglRecord.Create(id, reader);
    }
}