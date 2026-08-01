using BglReader.Types;

namespace BglReader.BinaryReaders;

public sealed class ShiftedIcaoIdentifierReader : IBinaryValueReader<IcaoIdentifier>
{
    public IcaoIdentifier Read(BglBinaryReader reader) => new(reader.ReadUInt32() >> 5);
}