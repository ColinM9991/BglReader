using BglReader.Airport.Subsections.Apron;

namespace BglReader.BinaryReaders;

public sealed class ApronTriangleReader : IBinaryValueReader<ApronTriangle>
{
    public ApronTriangle Read(BglBinaryReader reader) => new(reader.ReadUInt16(), reader.ReadUInt16(), reader.ReadUInt16());
}