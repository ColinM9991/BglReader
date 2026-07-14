using System.Text;

namespace BglReader.Scenery;

public class TaxiSignSceneryRecord : LibrarySceneryRecordBase
{
    private const int MemorySizeBytes = 12;

    public TaxiSignSceneryRecord(BinaryReader reader) : base(reader)
    {
        NumberOfSigns = reader.ReadUInt32();

        for (var i = 0; i < NumberOfSigns; i++)
        {
            var longitudeOffset = reader.ReadSingle();
            var latitudeOffset = reader.ReadSingle();

            var latitude =
                Coordinates.Latitude +
                latitudeOffset * 360.0 / 40007000.0;

            var longitude =
                Coordinates.Longitude +
                longitudeOffset * 360.0 /
                (40075000.0 *
                 Math.Cos((Math.PI / 180.0) *
                          Math.Abs(Coordinates.Latitude +
                                   latitudeOffset * 360.0 / 40007000.0 / 2.0)));

            Signs.Add(new TaxiWaySign(
                longitude,
                latitude,
                reader.ReadSingle(),
                reader.ReadInt16(),
                reader.ReadInt16(),
                (short)(reader.ReadInt16() * 360 / 65535),
                reader.ReadUInt16(),
                reader.ReadByte(),
                reader.ReadByte()
            ));

            var labelBytes = reader.ReadUntilNull();

            var label = Encoding.ASCII.GetString(labelBytes);
            var labelLength = MemorySizeBytes + labelBytes.Length + 1;
            if ((labelLength & 1) != 0)
            {
                reader.ReadByte(); // Consume alignment padding
            }
        }
    }

    public uint NumberOfSigns { get; }

    public ICollection<TaxiWaySign> Signs { get; } = [];
}

public sealed record TaxiWaySign(
    double LongitudeOffset,
    double LatitudeOffset,
    float Altitude,
    short Pitch,
    short Bank,
    short Heading,
    ushort Flags,
    byte Size,
    byte Justification);

public static class BinaryReaderExtensions
{
    extension(BinaryReader reader)
    {
        public byte[] ReadUntilNull()
        {
            Span<byte> buffer = stackalloc byte[64];
            var length = 0;
            
            byte b;
            while ((b = reader.ReadByte()) != 0)
            {
                buffer[length++] = b;
            }

            return buffer[..length].ToArray();
        }
    }
}