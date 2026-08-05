using BglReader.Types;

namespace BglReader.BinaryReaders;

public sealed class IcaoIdentifierReader : IBinaryValueReader<IcaoIdentifier>
{
    public static IcaoIdentifier Read(BglBinaryReader reader) => new(reader.ReadUInt32());
}