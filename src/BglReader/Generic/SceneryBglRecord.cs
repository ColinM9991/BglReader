using BglReader.Scenery;

namespace BglReader.Generic;

/// <inheritdoc/>
public class SceneryBglRecord : BaseBglRecord<ushort>
{
    protected SceneryBglRecord(ushort id, BglBinaryReader reader) : base(id, reader)
    {
    }

    public static SceneryBglRecord? GetSceneryBglRecord(ushort id, BglBinaryReader reader)
    {
        var sceneryType = (SceneryObjectType)id;
        var record = BglRecordFactory.Create(sceneryType, reader);
        
        return record;
    }
}