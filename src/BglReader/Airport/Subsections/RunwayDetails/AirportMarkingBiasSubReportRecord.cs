using BglReader.Generic;

namespace BglReader.Airport.Subsections.RunwayDetails;

public class AirportMarkingBiasSubReportRecord : BglRecord
{
    public AirportMarkingBiasSubReportRecord(ushort id, BglBinaryReader reader) : base(id, reader)
    {
        _ = reader.ReadUInt16();

        PrimaryMarking = reader.ReadSingle();
        SecondaryMarking = reader.ReadSingle();
    }

    public float PrimaryMarking { get; }

    public float SecondaryMarking { get; }
}