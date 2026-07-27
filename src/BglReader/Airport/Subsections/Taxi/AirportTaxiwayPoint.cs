using BglReader.Generic;

namespace BglReader.Airport.Subsections.Taxi;

public class AirportTaxiwayPoint : BglRecord
{
    public AirportTaxiwayPoint(ushort id, BglBinaryReader reader) : base(id, reader)
    {
        NumberOfPoints = reader.ReadUInt16();

        MapTaxiPoints(reader);
    }

    public ushort NumberOfPoints { get; }

    public ICollection<TaxiWayPoint> Points { get; } = new List<TaxiWayPoint>();

    public void MapTaxiPoints(BglBinaryReader reader)
    {
        if (NumberOfPoints == 0) return;

        for (var point = 0; point < NumberOfPoints; point++)
        {
            var type = (TaxiPointType)reader.ReadByte();
            var flag = (TaxiPointFlag)reader.ReadByte();
            _ = reader.ReadBytes(2); // TODO Padding?
            var coordinate = reader.ReadCoordinates();

            Points.Add(new TaxiWayPoint(type, flag, coordinate));
        }
    }
}