namespace BglReader.Airport;

[BinarySerializable]
public partial class AirportSummaryP3DRecord : AirportSummaryRecord
{
    [Binary(1)]
    [BinaryReader(typeof(GuidValueReader))]
    public Guid? MaterialSet { get; }
}