using BglReader.Generic;

namespace BglReader.Airport;

public class AirportMarkingBiasSubReportRecord : BglRecord
{
    public AirportMarkingBiasSubReportRecord(BglBinaryReader reader) : base(reader)
    {
        _ = reader.ReadUInt16();

        PrimaryMarking = reader.ReadSingle();
        SecondaryMarking = reader.ReadSingle();
    }

    public float PrimaryMarking { get; }

    public float SecondaryMarking { get; }
}