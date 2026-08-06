using BglReader.Types;

namespace BglReader.BinaryReaders;

public sealed class ThreeDimensionalCoordinateReader
    : IBinaryValueReader<Coordinate>
{
    public static Coordinate Read(BglBinaryReader reader) =>
        reader.ReadCoordinates(hasElevation: true);
}