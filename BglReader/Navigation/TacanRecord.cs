using BglReader.Airport;
using BglReader.Generic;
using BglReader.ValueObjects;

namespace BglReader.Navigation;

public class TacanRecord : BglRecord
{
    public TacanRecord(BglBinaryReader reader) : base(reader, false)
    {
        Coordinates = reader.ReadCoordinates();
        Channel = reader.ReadUInt32();

        Flags = new TacanFlags(reader.ReadByte());

        Range = reader.ReadSingle();
        MagneticVariation = (MagneticVariation)reader.ReadSingle();
        Identifier = new ShiftedIcaoIdentifier(reader.ReadUInt32());

        RegionFlags = new RegionFlags(reader.ReadUInt32());
        MapSubRecords(reader);
    }
    
    public Coordinate Coordinates { get; }
    
    public uint Channel { get; }
    
    public TacanFlags Flags { get; }
    
    public float Range { get; }
    
    public MagneticVariation MagneticVariation { get; }
    
    public ShiftedIcaoIdentifier Identifier { get; }
    
    public RegionFlags RegionFlags { get; }
    
    public ICollection<BglRecord> SubRecords { get; } = new List<BglRecord>();
    
    public void MapSubRecords(BglBinaryReader reader)
    {
        var recordSize = GetRecordEndPosition();

        while (reader.Position < recordSize)
        {
            var id = (NavigationDataType)reader.ReadUInt16();

            var record = BglRecordFactory.Create(id, reader);
            
            if (record is not null) SubRecords.Add(record);
        }
    }
}