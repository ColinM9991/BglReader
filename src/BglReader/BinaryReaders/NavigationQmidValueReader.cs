namespace BglReader.BinaryReaders;

public sealed class NavigationQmidValueReader : IBinaryValueReader<Qmid>
{
    public static Qmid Read(BglBinaryReader reader) => new Qmid(reader.ReadUInt16(), reader.ReadUInt16(), 9);
}