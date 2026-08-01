namespace BglReader.BinaryReaders;

public sealed class TrafficScalarReader : IBinaryValueReader<double>
{
    public double Read(BglBinaryReader reader) => reader.ReadByte() / 255.0;
}