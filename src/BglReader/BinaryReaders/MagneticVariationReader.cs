using BglReader.Types;

namespace BglReader.BinaryReaders;

public sealed class MagneticVariationReader : IBinaryValueReader<MagneticVariation>
{
    public MagneticVariation Read(BglBinaryReader reader) => new(reader.ReadSingle());
}