using BglReader.Types;

namespace BglReader.BinaryReaders;

public sealed class IcaoIdentifierReader : IBinaryValueReader<IcaoIdentifier>
{
    public IcaoIdentifier Read(BglBinaryReader reader) => new(reader.ReadUInt32());
}