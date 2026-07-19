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
    
    public Guid? MaterialSet { get; init; }
    
    public Elevation Elevation { get; init; }

    public ushort NumberOfVertices { get; init; }

    public ICollection<Coordinate> Vertices { get; init; }

    protected IEnumerable<Coordinate> ReadVertices(BglBinaryReader reader)
        => Enumerable.Range(0, NumberOfVertices).Select(_ => reader.ReadCoordinates(hasElevation: false));
}