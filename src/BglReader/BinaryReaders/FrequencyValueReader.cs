using BglReader.Airport.Subsections.Types;

namespace BglReader.BinaryReaders;

public sealed class FrequencyValueReader : IBinaryValueReader<Frequency>
{
    public Frequency Read(BglBinaryReader reader) => new Frequency(reader.ReadUInt32());
}