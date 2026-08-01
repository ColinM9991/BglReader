using BglReader.Airport.Subsections.Types;
using BglReader.Attributes.BinaryAttributes;
using BglReader.Generic;

namespace BglReader.Airport.Subsections.RunwayDetails;

[BinarySerializable]
public partial class AirportSubReportBaseRecord : BglRecord
{
    [Binary(1)]
    public SurfaceType SurfaceType { get; }
    
    [Binary(2)]
    public byte Unknown { get; }

    [Binary(3)]
    public float Length { get; }

    [Binary(4)]
    public float Width { get; }
}