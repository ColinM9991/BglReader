using BglReader.Scenery;

namespace BglReader.Airport;

public class TowerSceneryObjectRecord : IncludedSceneryObject
{
    public TowerSceneryObjectRecord(ushort id, BglBinaryReader reader) : base(id, reader)
    {
    }
}