using BglReader.Types;

namespace BglReader.BinaryReaders;

public sealed class AngleValueReader : IBinaryValueReader<Angle>
{
    public Angle Read(BglBinaryReader reader)
    {
        return new Angle(reader.ReadUInt16());
    }
}