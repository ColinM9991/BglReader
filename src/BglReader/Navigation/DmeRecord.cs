using BglReader.Generic;
using BglReader.Types;

namespace BglReader.Navigation;

public class DmeRecord : BglRecord
{
    public DmeRecord(ushort id, BglBinaryReader reader)
        : base(id, reader)
    {
        _ = reader.ReadBytes(2); // TODO unknown
        
        Coordinates = reader.ReadCoordinates();
        Range = reader.ReadSingle();
    }
    
    public Coordinate Coordinates { get; }
    
    public float Range { get; }
}