using BglReader.Airport.Subsections.Types;

namespace BglReader.BinaryReaders;

public sealed class FrequencyValueReader : IBinaryValueReader<Frequency>
{
    public static Frequency Read(BglBinaryReader reader) => new Frequency(reader.ReadUInt32());
}