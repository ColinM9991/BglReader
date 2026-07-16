using BglReader.Generic;

namespace BglReader.Airport;

public class HelipadRecord : BglRecord
{
    public HelipadRecord(BinaryReader reader) : base(reader)
    {
        SurfaceType = (SurfaceType)reader.ReadByte();
        Type = reader.ReadByte();
        Color = reader.ReadBytes(4);
        Coordinate = Coordinate.FromBgl(reader.ReadInt32(), reader.ReadInt32(), reader.ReadInt32());
        Length = reader.ReadSingle();
        Width = reader.ReadSingle();
        Heading = reader.ReadSingle();
    }

    public SurfaceType SurfaceType { get; }

    public byte Type { get; }

    public byte[] Color { get; }

    public Coordinate Coordinate { get; }

    public float Length { get; }

    public float Width { get; }

    public float Heading { get; }
}