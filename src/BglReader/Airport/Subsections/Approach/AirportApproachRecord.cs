using BglReader.Airport.Subsections.Types;
using BglReader.Generic;
using BglReader.Types;
using BglReader.ValueObjects.BitFields;

namespace BglReader.Airport.Subsections.Approach;

[BinarySerializable]
public partial class AirportApproachRecord : BglRecord
{
    [Binary(1)]
    public byte Suffix { get; }

    [Binary(2)]
    public byte RunwayNumber { get; }
    
    [Binary(3)]
    public ApproachFlags ApproachFlags { get; }

    [Binary(4)]
    public byte NumberOfTransitions { get; }

    [Binary(5)]
    public byte NumberOfApproachLegs { get; }

    [Binary(6)]
    public byte NumberOfMissedApproachLegs { get; }
    
    [Binary(7)]
    [BinaryReader(typeof(ApproachFixReader))]
    public (FixType Type, IcaoIdentifier Identifier) Fix { get; }

    [Binary(8)]
    public RegionIdentifierFlags FixRegionFlags { get; }

    [Binary(9)]
    public float Altitude { get; }

    [Binary(10)]
    public float Heading { get; }

    [Binary(11)]
    public float MissedAltitude { get; }

    [Binary(12)]
    [BinaryPolymorphicCollection(typeof(ApproachDataFactory), typeof(AirportApproachDataType))]
    public ICollection<BglRecord> SubRecords { get; } = [];
}