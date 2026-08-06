using BglReader.Airport.Subsections.RunwayDetails;

namespace BglReader.Airport.Subsections.Types;

[BinarySerializable]
public readonly partial struct DeleteRunway
{
    [Binary(1)]
    public SurfaceType SurfaceType { get; }

    [Binary(2)]
    public byte PrimaryRunway { get; }

    [Binary(3)]
    public byte SecondaryRunway { get; }

    [Binary(4)]
    public DeleteRunwayFlags Flags { get; }
}

[BitField(typeof(byte))]
public partial class DeleteRunwayFlags
{
    [Bits(0, 4)]
    public partial RunwayDesignator PrimaryRunwayDesignator { get; }
    
    [Bits(4, 4)]
    public partial RunwayDesignator SecondaryRunwayDesignator { get; }
}