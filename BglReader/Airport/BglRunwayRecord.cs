using BglReader.Generic;

namespace BglReader.Airport;

public class BglRunwayRecord : BglRecord
{
    public BglRunwayRecord(BinaryReader reader) : base(reader, false)
    {
        Data = reader.ReadBytes((int)Size - HeaderSize);
    }
    
    public byte[] Data { get; }
}