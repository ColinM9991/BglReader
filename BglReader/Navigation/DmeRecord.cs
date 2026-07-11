using BglReader.Generic;

namespace BglReader.Navigation;

public class DmeRecord : BglRecord
{
    public DmeRecord(BinaryReader reader)
        : base(reader)
    {
        _ = reader.ReadBytes(2); // unknown
        
        Coordinates = new Coordinate(reader.ReadInt32(), reader.ReadInt32(), reader.ReadInt32());
        Range = reader.ReadSingle();
    }
    
    public Coordinate Coordinates { get; }
    
    public float Range { get; }
}