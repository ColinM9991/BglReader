using System.Text;

namespace BglReader.Scenery;

public class TaxiSignSceneryRecord : LibrarySceneryRecordBase
{
    private const int MemorySizeBytes = 12;

    public TaxiSignSceneryRecord(BglBinaryReader reader) : base(reader)
    {
        NumberOfSigns = reader.ReadUInt32();

        Signs = Enumerable.Range(0, (int)NumberOfSigns).Select(_ => CreateTaxiWaySign(reader)).ToList();
    }

    public uint NumberOfSigns { get; }

    public ICollection<TaxiWaySign> Signs { get; } = [];

    private TaxiWaySign CreateTaxiWaySign(BglBinaryReader reader)
    {
        var longitudeOffset = reader.ReadSingle();
        var latitudeOffset = reader.ReadSingle();

        var longitude = CoordinateCalculator.OffsetLongitude(Coordinates.Longitude, Coordinates.Latitude, longitudeOffset);
        var latitude = CoordinateCalculator.OffsetLatitude(Coordinates.Latitude, latitudeOffset);
        var coordinates = new Coordinate(longitude, latitude, new Elevation(reader.ReadSingle()));

        var pitch = reader.ReadInt16();
        var bank = reader.ReadInt16();
        var heading = (short)(reader.ReadInt16() * 360 / 65535);
        var flags = (TaxiSignFlags)reader.ReadUInt16();
        var size = (TaxiSignSize)reader.ReadByte();
        var justification = (TaxiSignJustification)reader.ReadByte();

        var labelBytes = reader.ReadUntilNull();

        var label = Encoding.ASCII.GetString(labelBytes);
        var labelLength = MemorySizeBytes + labelBytes.Length + 1;
        if ((labelLength & 1) != 0)
        {
            reader.ReadByte(); // Consume alignment padding
        }

        return new TaxiWaySign(
            coordinates,
            pitch,
            bank,
            heading,
            flags,
            size,
            justification,
            label
        );
    }
}