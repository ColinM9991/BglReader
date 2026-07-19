using BglReader.ValueObjects;

namespace BglReader.Airport.Apron;

public class AirportApronRecord : AirportApronBaseRecord
{
    public AirportApronRecord(
        BglBinaryReader reader) : base(reader)
    {
        TerrainFlags = new TerrainFlags(reader.ReadByte());
        MaterialSet = new Guid(reader.ReadBytes(16));
        Elevation = Elevation.FromBgl(reader.ReadInt32());
        NumberOfVertices = reader.ReadUInt16();
        MapVertices(reader);
    }

    public TerrainFlags TerrainFlags { get; }
}