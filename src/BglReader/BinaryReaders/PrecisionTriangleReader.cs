using BglReader.Airport.Subsections.Types;

namespace BglReader.BinaryReaders;

public sealed class PrecisionTriangleReader : IBinaryValueReader<Triangle>
{
    public Triangle Read(BglBinaryReader reader) => new(reader.ReadSingle(), reader.ReadUInt16(), reader.ReadUInt16());
}