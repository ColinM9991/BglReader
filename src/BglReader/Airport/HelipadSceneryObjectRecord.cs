using BglReader.Generic;
using BglReader.Scenery;

namespace BglReader.Airport;

public sealed class HelipadSceneryObjectRecord : BglRecord
{
    public HelipadSceneryObjectRecord(BglBinaryReader reader) : base(reader)
    {
        ScenerySize = reader.ReadUInt32();
        
        LibrarySceneryRecord = new LibrarySceneryRecord(reader, false);
    }

    public uint ScenerySize { get; }
    
    public LibrarySceneryRecord LibrarySceneryRecord { get; set; }
}