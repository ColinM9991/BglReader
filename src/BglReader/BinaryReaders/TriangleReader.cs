using BglReader.Airport.Subsections.Types;

namespace BglReader.BinaryReaders;

public sealed class TriangleReader : IBinaryValueReader<Triangle>
{
    public static Triangle Read(BglBinaryReader reader) => new(reader.ReadUInt16(), reader.ReadUInt16(), reader.ReadUInt16());
}