namespace BglReader.BinaryReaders;

public sealed class GuidValueReader : IBinaryValueReader<Guid>
{
    public static Guid Read(BglBinaryReader reader) => new(reader.ReadBytes(16));
}