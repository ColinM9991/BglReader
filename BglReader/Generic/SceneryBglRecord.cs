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

        SceneryBglRecord? record = sceneryType switch
        {
            SceneryObjectType.TaxiSign
                or SceneryObjectType.TaxiSignFS9
                or SceneryObjectType.TaxiSignP3D => new TaxiSignSceneryRecord(reader),
            SceneryObjectType.LibraryObject
                or SceneryObjectType.LibraryObjectFS9 => new LibrarySceneryRecord(reader),
            _ => null,
        };

        return record;
    }
}