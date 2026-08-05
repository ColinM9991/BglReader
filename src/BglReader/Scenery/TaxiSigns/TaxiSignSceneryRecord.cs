using BglReader.Scenery.LibraryObjects;

namespace BglReader.Scenery.TaxiSigns;

[BinarySerializable]
public partial class TaxiSignSceneryRecord : LibrarySceneryRecordBase
{
    [Binary(1)]
    public int NumberOfSigns { get; }

    [Binary(2)]
    [BinaryConsume(32)]
    [BinaryCondition<SceneryObjectType>(nameof(Id), BinaryComparison.Equal, SceneryObjectType.TaxiSignP3DV6)]
    public byte[] Unknown { get; }
    
    [Binary(3)]
    [BinaryReader(typeof(TaxiWaySignReader))]
    [BinaryCollection(nameof(NumberOfSigns))]
    public ICollection<TaxiWaySign> Signs { get; private set; } = [];
}