namespace BglReader.BinaryReaders;

public sealed class GuidValueReader : IBinaryValueReader<Guid>
{
    public Guid Read(BglBinaryReader reader) => new(reader.ReadBytes(16));
}