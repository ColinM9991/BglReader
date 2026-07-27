using BglReader.Scenery.LibraryObjects;

namespace BglReader.Airport.Subsections;

public class TowerSceneryObjectRecord : IncludedSceneryObject
{
    public TowerSceneryObjectRecord(ushort id, BglBinaryReader reader) : base(id, reader)
    {
    }
}