using BglReader.Generic;

namespace BglReader.Airport.Subsections.RunwayDetails;

[BinarySerializable]
public partial class AirportMarkingBiasSubReportRecord : BglRecord
{
    [Binary(1)]
    [BinaryDiscard(2)]
    public byte[] Unknown { get; }

    [Binary(2)]
    public float PrimaryMarking { get; }

    [Binary(3)]
    public float SecondaryMarking { get; }
}