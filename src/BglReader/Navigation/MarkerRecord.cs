using BglReader.Generic;
using BglReader.Types;

namespace BglReader.Navigation;

[BinarySerializable]
public partial class MarkerRecord : BglRecord
{
    [Binary(1)]
    public byte Heading { get; }
    
    [Binary(2)]
    public MarkerType Type { get; }
    
    [Binary(3)]
    [BinaryReader(typeof(ThreeDimensionalCoordinateReader))]
    public Coordinate Coordinates { get; }
    
    [Binary(4)]
    [BinaryReader(typeof(ShiftedIcaoIdentifierReader))]
    public IcaoIdentifier Identifier { get; }
    
    [Binary(5)]
    [BinaryReader(typeof(HalfIcaoIdentifierReader))]
    public IcaoIdentifier Region { get; }
    
    [Binary(6)]
    [BinaryConsume(2)]
    public byte[] Unknown { get; }
}