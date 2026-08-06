using BglReader.Types;

namespace BglReader.BinaryReaders;

public sealed class TwoDimensionalCoordinateReader
    : IBinaryValueReader<Coordinate>
{
    public static Coordinate Read(BglBinaryReader reader) =>
        reader.ReadCoordinates(hasElevation: false);
}