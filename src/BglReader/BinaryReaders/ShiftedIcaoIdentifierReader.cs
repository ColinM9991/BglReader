using BglReader.Types;

namespace BglReader.BinaryReaders;

public sealed class ShiftedIcaoIdentifierReader : IBinaryValueReader<IcaoIdentifier>
{
    public static IcaoIdentifier Read(BglBinaryReader reader) => new(reader.ReadUInt32() >> 5);
}