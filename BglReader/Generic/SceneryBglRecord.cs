using BglReader.Airport;
using BglReader.Scenery;

namespace BglReader.Generic;

/// <inheritdoc/>
public class SceneryBglRecord : BglRecord<ushort>
{
    protected SceneryBglRecord(BinaryReader reader, bool shouldRewindStream = true) : base(reader, shouldRewindStream)
    {
    }

    public static SceneryBglRecord? GetSceneryBglRecord(BinaryReader reader)
    {
        var sceneryType = (SceneryObjectType)reader.ReadUInt16();
        var record = BglRecordFactory.Create(sceneryType, reader);
        
        return record;
    }
}