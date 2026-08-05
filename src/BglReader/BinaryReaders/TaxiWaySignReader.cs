using BglReader.Scenery.TaxiSigns;
using BglReader.Types;

namespace BglReader.BinaryReaders;

public sealed class TaxiWaySignReader : IBinaryRecordReader<TaxiWaySign>
{
    public TaxiWaySign Read(BglRecordContext context, BglBinaryReader reader)
    {
        if (context.ParentRecord is not TaxiSignSceneryRecord record)
        {
            throw new InvalidOperationException("Invalid parent record type");
        }
        
        var longitudeOffset = reader.ReadSingle();
        var latitudeOffset = reader.ReadSingle();

        var longitude = CoordinateCalculator.OffsetLongitude(record.Coordinates.Longitude, record.Coordinates.Latitude, longitudeOffset);
        var latitude = CoordinateCalculator.OffsetLatitude(record.Coordinates.Latitude, latitudeOffset);
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