using BglReader.Airport;
using BglReader.Generic;
using BglReader.Types;
using BglReader.ValueObjects.BitFields;

namespace BglReader.Navigation;

[BinarySerializable]
public partial class BoundaryRecord : BglRecord
{
    [Binary(1)]
    public byte Type { get; }

    [Binary(2)]
    public BoundaryFlags Flags { get; }

    [Binary(3)]
    [BinaryReader(typeof(ThreeDimensionalCoordinateReader))]
    public Coordinate MinimumCoordinates { get; }

    [Binary(4)]
    [BinaryReader(typeof(ThreeDimensionalCoordinateReader))]
    public Coordinate MaximumCoordinates { get; }

    [Binary(5)]
    [BinaryPolymorphicCollection(typeof(NavigationDataFactory), typeof(NavigationDataType))]
    public ICollection<BglRecord> SubRecords { get; } = [];
}