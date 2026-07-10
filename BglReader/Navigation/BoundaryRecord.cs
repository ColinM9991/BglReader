using BglReader.Generic;
using BglReader.ValueObjects;

namespace BglReader.Navigation;

public class BoundaryRecord : BglRecord
{
    public BoundaryRecord(BinaryReader reader) : base(reader, false)
    {
        Type = reader.ReadByte();
        
        Flags = new BoundaryFlags(reader.ReadByte());

        MinimumCoordinates = new Coordinate(reader.ReadInt32(), reader.ReadInt32(), reader.ReadInt32());
        MaximumCoordinates = new Coordinate(reader.ReadInt32(), reader.ReadInt32(), reader.ReadInt32());

        Name = new NameRecord(reader, shouldRewindStream: false);
    }
    
    public byte Type { get; }
    
    public BoundaryFlags Flags { get; }
    
    public Coordinate MinimumCoordinates { get; }
    
    public Coordinate MaximumCoordinates { get; }
    
    public NameRecord Name { get; }
}