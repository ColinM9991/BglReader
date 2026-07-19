using BglReader.ValueObjects;

namespace BglReader.Airport.Apron;

public class AirportApronSecondRecord : AirportApronBaseRecord
{
    public AirportApronSecondRecord(
        BglBinaryReader reader) : base(reader)
    {
        Flags = new ApronFlags(reader.ReadByte());
        MaterialSet = new Guid(reader.ReadBytes(16));
        Elevation = Elevation.FromBgl(reader.ReadInt32());
        NumberOfVertices = reader.ReadUInt16();
        NumberOfTriangles = reader.ReadUInt16();
        Vertices = ReadVertices(reader).ToList();
        Triangles = Enumerable.Range(0, NumberOfTriangles).Select(_ => new ApronTriangle(
            reader.ReadUInt16(),
            reader.ReadUInt16(),
            reader.ReadUInt16())).ToList();
    }

    public ApronFlags Flags { get; }

    public ushort NumberOfTriangles { get; }

    public ICollection<ApronTriangle> Triangles { get; }
}