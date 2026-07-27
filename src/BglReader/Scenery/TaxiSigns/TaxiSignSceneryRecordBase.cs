using System.Text;
using BglReader.Scenery.LibraryObjects;

namespace BglReader.Scenery.TaxiSigns;

public abstract class TaxiSignSceneryRecordBase : LibrarySceneryRecordBase
{
    protected TaxiSignSceneryRecordBase(ushort id, BglBinaryReader reader) : base(id, reader)
    {
        NumberOfSigns = reader.ReadUInt32();
    }
    
    public uint NumberOfSigns { get; }

    public ICollection<TaxiWaySign> Signs { get; private set; } = [];

    protected void CreateSigns(BglBinaryReader reader)
    {
        Signs = Enumerable.Range(0, (int)NumberOfSigns).Select(_ => CreateTaxiWaySign(reader)).ToList();
    }
    
    private TaxiWaySign CreateTaxiWaySign(BglBinaryReader reader)
    {
        const int memorySizeBytes = 12;
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
        var labelLength = memorySizeBytes + labelBytes.Length + 1;
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