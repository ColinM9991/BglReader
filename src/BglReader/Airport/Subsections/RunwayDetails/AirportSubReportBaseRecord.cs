using BglReader.Airport.Subsections.Types;
using BglReader.Generic;

namespace BglReader.Airport.Subsections.RunwayDetails;

public class AirportSubReportBaseRecord : BglRecord
{
    public AirportSubReportBaseRecord(
        ushort id,
        BglBinaryReader reader,
        SubReportBaseType type) : base(id, reader)
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