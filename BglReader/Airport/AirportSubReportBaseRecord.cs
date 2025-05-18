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

    public SubReportBaseType Type { get; set; }

    public SurfaceType SurfaceType { get; set; }

    public float Length { get; set; }

    public float Width { get; set; }

    public enum SubReportBaseType
    {
        OffsetThreshold,
        BlastPad,
        Overrun
    }
}