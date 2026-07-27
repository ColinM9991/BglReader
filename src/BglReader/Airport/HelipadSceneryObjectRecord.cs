using BglReader.Scenery;

namespace BglReader.Airport;

public sealed class HelipadSceneryObjectRecord : IncludedSceneryObject
{
    public HelipadSceneryObjectRecord(ushort id, BglBinaryReader reader) : base(id, reader)
    {
    }
}