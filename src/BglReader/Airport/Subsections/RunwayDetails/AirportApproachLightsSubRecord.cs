using BglReader.Generic;
using BglReader.ValueObjects.BitFields;

namespace BglReader.Airport.Subsections.RunwayDetails;

[BinarySerializable]
public partial class AirportApproachLightsSubRecord : BglRecord
{
    [Binary(1)]
    public ApproachLightsFlags Flags { get; }

    [Binary(2)]
    public byte NumberOfStrobes { get; }
}