using BglReader.ValueObjects;

namespace BglReader.Airport;

public class AirportApronSecondRecord : AirportApronBaseRecord
{
    public AirportApronSecondRecord(
        BinaryReader reader) : base(reader)
    {
        Flags = new ApronFlags(reader.ReadByte());
        _ = reader.ReadBytes(20);
        NumberOfVertices = reader.ReadUInt16();
        NumberOfTriangles = reader.ReadUInt16();
        MapVertices(reader);
        MapTriangles(reader);
        reader.BaseStream.Position = GetRecordEndPosition();
    }

    public ApronFlags Flags { get; }

    public ushort NumberOfTriangles { get; }

    public ICollection<ApronTriangle> Triangles { get; } = new List<ApronTriangle>();

    private void MapTriangles(BinaryReader reader)
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