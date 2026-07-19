using BglReader.Generic;

namespace BglReader.Airport.Apron;

// TODO Validate Apron types being used in P3DV5
public abstract class AirportApronBaseRecord : BglRecord
{
    public AirportApronBaseRecord(
        BglBinaryReader reader) : base(reader)
    {
        SurfaceType = (SurfaceType)reader.ReadByte();
    }

    public SurfaceType SurfaceType { get; init; }
    
    public Guid MaterialSet { get; init; }
    
    public Elevation Elevation { get; init; }

    public ushort NumberOfVertices { get; init; }

    public ICollection<Coordinate> Vertices { get; } = new List<Coordinate>();

    protected void MapVertices(BglBinaryReader reader)
    {
        if (NumberOfVertices == 0) return;

        for (var vertex = 0; vertex < NumberOfVertices; vertex++)
        {
            Vertices.Add(reader.ReadCoordinates(hasElevation: false));
        }
    }
}