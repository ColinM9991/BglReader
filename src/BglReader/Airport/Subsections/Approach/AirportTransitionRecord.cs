using BglReader.Airport.Subsections.Types;
using BglReader.Generic;
using BglReader.Types;
using BglReader.ValueObjects.BitFields;

namespace BglReader.Airport.Subsections.Approach;

[BinarySerializable]
public partial class AirportTransitionRecord : BglRecord
{
    [Binary(0)]
    public TransitionType Type { get; }

    [Binary(1)]
    public byte NumberOfTransitionLegs { get; }

    [Binary(2)]
    [BinaryReader(typeof(ApproachFixReader))]
    public (FixType Type, IcaoIdentifier Identifier) Fix { get; }
    
    [Binary(3)]
    public RegionIdentifierFlags FixRegionFlags { get; }

    [Binary(4)]
    public float Altitude { get; }

    [Binary(5)]
    [BinaryCondition<TransitionType>(nameof(Type), BinaryComparison.Equal, TransitionType.Dme)]
    public TransitionDmeRecord? TransitionDme { get; }

    [Binary(6)]
    public AirportLegBaseRecord? LegRecord { get; }
}