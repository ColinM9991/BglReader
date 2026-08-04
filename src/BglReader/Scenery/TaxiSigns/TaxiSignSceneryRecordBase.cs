using System.Text;
using BglReader.Scenery.LibraryObjects;
using BglReader.Types;

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
        var longitudeOffset = reader.ReadSingle();
        var latitudeOffset = reader.ReadSingle();

        var longitude = CoordinateCalculator.OffsetLongitude(Coordinates.Longitude, Coordinates.Latitude, longitudeOffset);
        var latitude = CoordinateCalculator.OffsetLatitude(Coordinates.Latitude, latitudeOffset);
        var coordinates = new Coordinate(longitude, latitude, new Elevation(reader.ReadSingle()));

        var pitch = new Angle(reader.ReadUInt16());
        var bank = new Angle(reader.ReadUInt16());
        var heading = new Angle(reader.ReadUInt16());
        var flags = (TaxiSignFlags)reader.ReadUInt16();
        var size = (TaxiSignSize)reader.ReadByte();
        var justification = (TaxiSignJustification)reader.ReadByte();

        var label = reader.ReadNullTerminatedString(2);

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