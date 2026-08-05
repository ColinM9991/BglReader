namespace BglReader.BinaryReaders;

public sealed class IsSlopedValueReader : IBinaryValueReader<bool>
{
    public static bool Read(BglBinaryReader reader) => reader.ReadUInt16() == 1;
}