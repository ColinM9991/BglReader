using BglReader.Generic;

namespace BglReader.Airport.Subsections;

[BinarySerializable]
public partial class AirportJetwayRecord : BglRecord
{
    [Binary(1)]
    public ushort ParkingNumber { get; }
    
    [Binary(2)]
    public ushort GateName { get; }
    
    [Binary(3)]
    public uint SceneryObjectSize { get; }
    
    [Binary(4)]
    [BinaryConsume(nameof(SceneryObjectSize))]
    public byte[] SceneryObject { get; } = [];
}