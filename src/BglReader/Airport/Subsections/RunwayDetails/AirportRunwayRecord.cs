using BglReader.Airport.Subsections.Types;
using BglReader.Attributes.BinaryAttributes;
using BglReader.Generic;
using BglReader.Types;
using BglReader.ValueObjects;
using BglReader.ValueObjects.BitFields;

namespace BglReader.Airport.Subsections.RunwayDetails;

[BinarySerializable]
public partial class AirportRunwayRecord : BglRecord
{
    [Binary(1)]
    public SurfaceType SurfaceType { get; }
    
    [Binary(2)]
    public byte Unknown { get; }

    [Binary(3)]
    public byte RunwayNumber { get; }

    [Binary(4)]
    public RunwayDesignator Designator { get; }

    [Binary(5)]
    public byte SecondaryRunwayNumber { get; }

    [Binary(6)]
    public RunwayDesignator SecondaryRunwayDesignator { get; }

    [Binary(7)]
    [BinaryReader(typeof(IcaoIdentifierReader))]
    public IcaoIdentifier PrimaryIlsIdentifier { get; }

    [Binary(8)]
    [BinaryReader(typeof(IcaoIdentifierReader))]
    public IcaoIdentifier SecondaryIlsIdentifier { get; }

    [Binary(9)]
    [BinaryReader(typeof(ThreeDimensionalCoordinateReader))]
    public Coordinate Coordinates { get; }

    [Binary(10)]
    public float Length { get; }

    [Binary(11)]
    public float Width { get; }

    [Binary(12)]
    public float Heading { get; }

    [Binary(13)]
    public float PatternAltitude { get; }

    [Binary(14)]
    public RunwayMarkingFlags MarkingFlags { get; }

    [Binary(15)]
    public RunwayLightFlags LightsFlags { get; }

    [Binary(16)]
    public RunwayPatternFlags PatternFlags { get; }

    [Binary(17)]
    [BinaryReader(typeof(GuidValueReader))]
    [BinaryCondition<AirportSubsectionDataType>(nameof(Id), BinaryComparison.NotEqual, AirportSubsectionDataType.Runway)]
    public Guid? Material { get; }

    [Binary(18)]
    [BinaryPolymorphicCollection(typeof(BglRecordFactory), typeof(AirportRecordDataType))]
    public ICollection<BglRecord> SubRecords { get; } = new List<BglRecord>();
}