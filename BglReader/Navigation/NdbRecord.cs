using BglReader.Airport;
using BglReader.Generic;
using BglReader.ValueObjects;

namespace BglReader.Navigation;

public class NdbRecord : BglRecord
{
    public NdbRecord(BinaryReader reader) : base(reader, false)
    {
        Type = (NdbType)reader.ReadUInt16();
        Frequency = reader.ReadUInt32();
        Coordinates = new Coordinate(reader.ReadInt32(), reader.ReadInt32(), reader.ReadInt32());
        Range = reader.ReadSingle();
        MagneticVariation = (MagneticVariation)reader.ReadSingle();
        Identifier = new ShiftedIcaoIdentifier(reader.ReadUInt32());

        RegionFlags = new RegionIdentifierFlags(reader.ReadUInt32());
        
        MapSubRecords(reader);
    }
    
    public NdbType Type { get; }
    
    public uint Frequency { get; }
    
    public Coordinate Coordinates { get; }
    
    public float Range { get; }
    
    public MagneticVariation MagneticVariation { get; }
    
    public ShiftedIcaoIdentifier Identifier { get; }
    
    public RegionFlags RegionFlags { get; }
    
    public ICollection<BglRecord> SubRecords { get; } = new List<BglRecord>();

    public void MapSubRecords(BinaryReader reader)
    {
        while (reader.BaseStream.Position < GetRecordEndPosition())
        {
            var id = (NavigationDataType)reader.ReadUInt16();
            var record = BglRecordFactory.Create(id, reader);
            if (record is not null) SubRecords.Add(record);
        }
    }
}

public enum NdbType : short
{
    CompassPoint = 0,
    MediumHoming = 1,
    Homing = 2,
    HighHoming = 3
}