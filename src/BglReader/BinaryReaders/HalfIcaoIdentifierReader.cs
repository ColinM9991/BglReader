using BglReader.Types;

namespace BglReader.BinaryReaders;

public sealed class HalfIcaoIdentifierReader : IBinaryValueReader<IcaoIdentifier>
{
    public static IcaoIdentifier Read(BglBinaryReader reader) => new(reader.ReadUInt16());
}