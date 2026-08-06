using BglReader.Generic;
using BglReader.Types;

namespace BglReader.Airport.Subsections;

[BinarySerializable]
public partial class AirportFenceRecord : BglRecord
{
    [Binary(1)]
    public ushort NumberOfVertices { get; }
    
    [Binary(2)]
    [BinaryReader(typeof(GuidValueReader))]
    public Guid Instance { get; }
    
    [Binary(3)]
    [BinaryReader(typeof(GuidValueReader))]
    public Guid Profile { get; }

    [Binary(4)]
    [BinaryReader(typeof(TwoDimensionalCoordinateReader))]
    [BinaryCollection(nameof(NumberOfVertices))]
    public ICollection<Coordinate> Vertices { get; } = [];
}