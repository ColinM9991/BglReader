using BglReader.Types;

namespace BglReader.BinaryReaders;

public sealed class ElevationBinaryValueReader : IBinaryValueReader<Elevation>
{
    public static Elevation Read(BglBinaryReader reader) => new(reader.ReadInt32() / 1000f);
}