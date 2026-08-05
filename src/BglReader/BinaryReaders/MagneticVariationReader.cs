using BglReader.Types;

namespace BglReader.BinaryReaders;

public sealed class MagneticVariationReader : IBinaryValueReader<MagneticVariation>
{
    public static MagneticVariation Read(BglBinaryReader reader) => new(reader.ReadSingle());
}