using BglReader.Types;

namespace BglReader.BinaryReaders;

public sealed class ElevationBinaryValueReader : IBinaryValueReader<Elevation>
{
    public Elevation Read(BglBinaryReader reader) => new(reader.ReadInt32() / 1000f);
}