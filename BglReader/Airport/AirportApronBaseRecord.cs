using BglReader.Generic;

namespace BglReader.Airport;

// TODO Validate Apron types being used in P3DV5
public abstract class AirportApronBaseRecord : BglRecord
{
    public AirportApronBaseRecord(
        BinaryReader reader) : base(reader)
    {
        SurfaceType = (SurfaceType)reader.ReadByte();
    }

    public SurfaceType SurfaceType { get; init; }

    public ushort NumberOfVertices { get; init; }

    public ICollection<Coordinate> Vertices { get; } = new List<Coordinate>();

    protected void MapVertices(BinaryReader reader)
    {
        if (NumberOfVertices == 0) return;

        for (var vertex = 0; vertex < NumberOfVertices; vertex++)
        {
            Vertices.Add(new Coordinate(
                reader.ReadInt32(),
                reader.ReadInt32()));
        }
    }
}