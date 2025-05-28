using BglReader.Generic;

namespace BglReader.Airport;

public class AirportSubReportBaseRecord : BglRecord
{
    public AirportSubReportBaseRecord(
        BinaryReader reader,
        SubReportBaseType type) : base(reader)
    {
        Type = type;
        SurfaceType = (SurfaceType)reader.ReadUInt16();
        Length = reader.ReadSingle();
        Width = reader.ReadSingle();
    }

    public SubReportBaseType Type { get; }

    public SurfaceType SurfaceType { get; }

    public float Length { get; }

    public float Width { get; }

    public enum SubReportBaseType
    {
        OffsetThreshold,
        BlastPad,
        Overrun
    }
}