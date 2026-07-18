using BglReader.ValueObjects;

namespace BglReader.Airport;

public class AirportApronSecondRecord : AirportApronBaseRecord
{
    public AirportApronSecondRecord(
        BglBinaryReader reader) : base(reader)
    {
        Flags = new ApronFlags(reader.ReadByte());
        _ = reader.ReadBytes(20);
        NumberOfVertices = reader.ReadUInt16();
        NumberOfTriangles = reader.ReadUInt16();
        MapVertices(reader);
        MapTriangles(reader);
    }

    public ApronFlags Flags { get; }

    public ushort NumberOfTriangles { get; }

    public ICollection<ApronTriangle> Triangles { get; } = new List<ApronTriangle>();

    private void MapTriangles(BglBinaryReader reader)
    {
        if (NumberOfTriangles == 0) return;

        for (var triangle = 0; triangle < NumberOfTriangles; triangle++)
        {
            Triangles.Add(new ApronTriangle(
                reader.ReadUInt16(),
                reader.ReadUInt16(),
                reader.ReadUInt16()));
        }
    }
}