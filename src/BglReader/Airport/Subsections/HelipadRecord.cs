using BglReader.Airport.Subsections.Types;
using BglReader.Generic;
using BglReader.Types;

namespace BglReader.Airport.Subsections;

[BinarySerializable]
public partial class HelipadRecord : BglRecord
{
    // public HelipadRecord(ushort id, BglBinaryReader reader) : base(id, reader)
    // {
    //     SurfaceType = (SurfaceType)reader.ReadByte();
    //     Type = reader.ReadByte();
    //     Color = reader.ReadBytes(4);
    //     Coordinate = reader.ReadCoordinates();
    //     Length = reader.ReadSingle();
    //     Width = reader.ReadSingle();
    //     Heading = reader.ReadSingle();
    // }

    [Binary(1)]
    public SurfaceType SurfaceType { get; }

    [Binary(2)]
    public byte Type { get; }

    [Binary(3)]
    [BinaryConsume(4)]
    public byte[] Color { get; }

    [Binary(4)]
    [BinaryReader(typeof(ThreeDimensionalCoordinateReader))]
    public Coordinate Coordinate { get; }

    [Binary(5)]
    public float Length { get; }

    [Binary(6)]
    public float Width { get; }

    [Binary(7)]
    public float Heading { get; }
}