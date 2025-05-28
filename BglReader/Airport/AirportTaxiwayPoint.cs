using BglReader.Generic;

namespace BglReader.Airport;

public class AirportTaxiwayPoint : BglRecord
{
    public AirportTaxiwayPoint(BinaryReader reader) : base(reader)
    {
        NumberOfPoints = reader.ReadUInt16();

        MapTaxiPoints(reader);
    }

    public ushort NumberOfPoints { get; }

    public ICollection<TaxiPoint> Points { get; } = new List<TaxiPoint>();

    public void MapTaxiPoints(BinaryReader reader)
    {
        if (NumberOfPoints == 0) return;

        for (var point = 0; point < NumberOfPoints; point++)
        {
            var type = reader.ReadByte();
            var flag = reader.ReadByte();
            _ = reader.ReadBytes(2);
            var longitude = reader.ReadInt32();
            var latitude = reader.ReadInt32();

            _ = reader.ReadBytes(4);

            Points.Add(new TaxiPoint(type, flag, longitude, latitude));
        }
    }
}