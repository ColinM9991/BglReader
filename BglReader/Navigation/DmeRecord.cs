using BglReader.Generic;

namespace BglReader.Navigation;

public class DmeRecord : BglRecord
{
    public DmeRecord(BglBinaryReader reader)
        : base(reader)
    {
        _ = reader.ReadBytes(2); // TODO unknown
        
        Coordinates = reader.ReadCoordinates();
        Range = reader.ReadSingle();
    }
    
    public Coordinate Coordinates { get; }
    
    public float Range { get; }
}