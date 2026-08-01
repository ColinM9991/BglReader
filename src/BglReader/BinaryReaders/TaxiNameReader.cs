namespace BglReader.BinaryReaders;

public sealed class TaxiNameReader : IBinaryValueReader<string>
{
    public string Read(BglBinaryReader reader) => reader.ReadString(8);
}