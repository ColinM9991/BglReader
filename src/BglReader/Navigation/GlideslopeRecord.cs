using BglReader.Generic;
using BglReader.Types;

namespace BglReader.Navigation;

[BinarySerializable]
public partial class GlideslopeRecord : BglRecord
{
    [Binary(1)]
    [BinaryConsume(2)]
    public byte[] Unknown { get; }

    [Binary(2)]
    [BinaryReader(typeof(ThreeDimensionalCoordinateReader))]
    public Coordinate Coordinates { get; }

    [Binary(3)]
    public float Range { get; }

    [Binary(4)]
    public float Pitch { get; }
}