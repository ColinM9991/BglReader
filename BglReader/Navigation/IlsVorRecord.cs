using BglReader.Airport;
using BglReader.Generic;
using BglReader.ValueObjects;

namespace BglReader.Navigation;

public class IlsVorRecord : BglRecord
{
    public IlsVorRecord(BinaryReader reader) : base(reader, false)
    {
        Type = (IlsVorType)reader.ReadByte();

        Flags = new IlsVorFlag(reader.ReadByte());
        
        Coordinates = new Coordinate(reader.ReadInt32(), reader.ReadInt32(), reader.ReadInt32());

        Frequency = (Frequency)reader.ReadUInt32();
        Range = reader.ReadSingle();
        MagneticVariation = (MagneticVariation)reader.ReadSingle();
        Identifier = new ShiftedIcaoIdentifier(reader.ReadUInt32());

        RegionFlags = new RegionIdentifierFlags(reader.ReadUInt32());
        
        MapSubRecords(reader);
    }
    
    public IlsVorType Type { get; }
    
    public IlsVorFlag Flags { get; }
    
    public Coordinate Coordinates { get; }
    
    public Frequency Frequency { get; }
    
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