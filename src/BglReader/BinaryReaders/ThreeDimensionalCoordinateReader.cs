using BglReader.Types;

namespace BglReader.BinaryReaders;

public sealed class ThreeDimensionalCoordinateReader
    : IBinaryValueReader<Coordinate>
{
    public Coordinate Read(BglBinaryReader reader) =>
        reader.ReadCoordinates(hasElevation: true);
}