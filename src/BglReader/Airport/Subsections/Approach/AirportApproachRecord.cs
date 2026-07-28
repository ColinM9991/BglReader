using BglReader.Airport.Subsections.Types;
using BglReader.Attributes.BinaryAttributes;
using BglReader.Generic;
using BglReader.Types;
using ApproachFlags = BglReader.ValueObjects.BitFields.ApproachFlags;
using RegionIdentifierFlags = BglReader.ValueObjects.BitFields.RegionIdentifierFlags;

namespace BglReader.Airport.Subsections.Approach;

[BinarySerializable]
public partial class AirportApproachRecord : BglRecord
{
    [Binary(0)]
    public byte Suffix { get; }

    [Binary(1)]
    public byte RunwayNumber { get; }
    
    [Binary(2)]
    public ApproachFlags ApproachFlags { get; }

    [Binary(3)]
    public byte NumberOfTransitions { get; }

    [Binary(4)]
    public byte NumberOfApproachLegs { get; }

    [Binary(5)]
    public byte NumberOfMissedApproachLegs { get; }
    
    [Binary(6)]
    [BinaryReader(typeof(ApproachFixReader))]
    public (FixType Type, IcaoIdentifier Identifier) Fix { get; }

    [Binary(7)]
    public RegionIdentifierFlags FixRegionFlags { get; }

    [Binary(8)]
    public float Altitude { get; }

    [Binary(9)]
    public float Heading { get; }

    [Binary(10)]
    public float MissedAltitude { get; }

    [Binary(11)]
    [BinaryCondition(nameof(NumberOfApproachLegs))]
    public AirportLegBaseRecord ApproachLegs { get; }

    [Binary(12)]
    [BinaryCondition(nameof(NumberOfMissedApproachLegs))]
    public AirportLegBaseRecord MissedApproachLegs { get; }

    [Binary(13)]
    [BinaryCondition(nameof(NumberOfTransitions))]
    public AirportTransitionRecord Transitions { get; }
}