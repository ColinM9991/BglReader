using BglReader.Scenery.LibraryObjects;

namespace BglReader.Airport.Subsections;

public sealed class HelipadSceneryObjectRecord : IncludedSceneryObject
{
    public HelipadSceneryObjectRecord(ushort id, BglBinaryReader reader) : base(id, reader)
    {
    }
}