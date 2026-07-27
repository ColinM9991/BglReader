using BglReader.Generic;
using BglReader.Scenery;

namespace BglReader.Airport;

public sealed class HelipadSceneryObjectRecord : BglRecord
{
    public HelipadSceneryObjectRecord(ushort id, BglBinaryReader reader) : base(id, reader)
    {
        ScenerySize = reader.ReadUInt32();

        LibrarySceneryRecord = SceneryBglRecord.GetSceneryBglRecord(reader.ReadUInt16(), reader);
    }

    public uint ScenerySize { get; }
    
    public SceneryBglRecord? LibrarySceneryRecord { get; set; }
}