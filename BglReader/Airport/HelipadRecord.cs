namespace BglReader.Airport;

public class HelipadRecord : BglRecord
{
    public HelipadRecord(BinaryReader reader) : base(reader)
    {
        SurfaceType = (SurfaceType)reader.ReadByte();
        Type = reader.ReadByte();
        Color = reader.ReadBytes(4);
        Coordinate = new Coordinate(reader.ReadInt32(), reader.ReadInt32(), reader.ReadInt32());
        Length = reader.ReadSingle();
        Width = reader.ReadSingle();
        Heading = reader.ReadSingle();
    }

    public SurfaceType SurfaceType { get; set; }

    public byte Type { get; set; }

    public byte[] Color { get; set; }

    public Coordinate Coordinate { get; set; }

    public float Length { get; set; }

    public float Width { get; set; }

    public float Heading { get; set; }
}