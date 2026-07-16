using BglReader.Generic;

namespace BglReader.Airport;

public class AirportFenceRecord : BglRecord
{
    public AirportFenceRecord(BinaryReader reader) : base(reader)
    {
        NumberOfVertices = reader.ReadUInt16();
        Instance = new Guid(reader.ReadBytes(16));
        Profile = new Guid(reader.ReadBytes(16));
        
        MapVertices(reader);
    }
    
    public ushort NumberOfVertices { get; }
    
    public Guid Instance { get; }
    
    public Guid Profile { get; }
    
    public ICollection<Coordinate> Vertices { get; } = new List<Coordinate>();

    private void MapVertices(BinaryReader reader)
    {
        if (NumberOfVertices == 0) return;

        for (var i = 0; i < NumberOfVertices; i++)
        {
            Vertices.Add(Coordinate.FromBgl(reader.ReadInt32(), reader.ReadInt32()));
        }
    }
}