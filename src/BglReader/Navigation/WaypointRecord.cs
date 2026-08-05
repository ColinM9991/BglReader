using BglReader.Generic;
using BglReader.Types;
using BglReader.ValueObjects.BitFields;

namespace BglReader.Navigation;

/// <summary>
/// TODO: Additional 2 bytes missing from certain records
/// </summary>
[BinarySerializable]
public partial class WaypointRecord : BglRecord
{
    [Binary(1)]
    public WaypointType Type { get; }
    
    [Binary(2)]
    public byte NumberOfRoutes { get; }
    
    [Binary(3)]
    [BinaryReader(typeof(TwoDimensionalCoordinateReader))]
    public Coordinate Coordinate { get; }
    
    [Binary(4)]
    [BinaryReader(typeof(MagneticVariationReader))]
    public MagneticVariation MagneticVariation { get; }
    
    [Binary(5)]
    [BinaryReader(typeof(ShiftedIcaoIdentifierReader))]
    public IcaoIdentifier Identifier { get; }
    
    [Binary(6)]
    public RegionFlags RegionFlags { get; }

    [Binary(7)]
    [BinaryCollection(nameof(NumberOfRoutes))]
    public ICollection<WaypointRoute> Routes { get; } = [];
}