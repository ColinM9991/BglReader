using BglReader.Airport;
using BglReader.Generic;

namespace BglReader.Navigation;

public class IlsVorRecord : BglRecord
{
    public IlsVorRecord(BinaryReader reader) : base(reader, false)
    {
        Type = (IlsVorType)reader.ReadByte();

        var flags = reader.ReadByte();

        IsDmeOnly = (flags & 0x1) == 0x0;
        IsBackcourse = (flags & 0x4) == 0x4;
        IsGlideslopePresent = (flags & 0x8) == 0x8;
        IsDmePresent = (flags & 0x10) == 0x10;
        NavTrue = (flags & 0x20) == 0x20;
        
        Coordinates = new Coordinate(reader.ReadInt32(), reader.ReadInt32(), reader.ReadInt32());

        Frequency = reader.ReadUInt32();
        Range = reader.ReadSingle();
        MagneticVariation = (MagneticVariation)reader.ReadSingle();
        Identifier = IcaoIdentifier.Parse(reader.ReadUInt32(), true);

        var regionFlags = reader.ReadUInt32();

        Region = IcaoIdentifier.Parse(regionFlags & 0x7FF);
        IlsAirport = IcaoIdentifier.Parse((regionFlags >> 11) & 0x1FFFFF);
        
        MapSubRecords(reader);
    }
    
    public IlsVorType Type { get; }
    
    public bool IsDmeOnly { get; }
    
    public bool IsBackcourse { get; }
    
    public bool IsGlideslopePresent { get; }
    
    public bool IsDmePresent { get; }
    
    public bool NavTrue { get; }
    
    public Coordinate Coordinates { get; }
    
    public uint Frequency { get; }
    
    public float Range { get; }
    
    public MagneticVariation MagneticVariation { get; }
    
    public IcaoIdentifier Identifier { get; }
    
    public IcaoIdentifier Region { get; }
    
    public IcaoIdentifier IlsAirport { get; }

    public ICollection<BglRecord> SubRecords { get; } = new List<BglRecord>();
    
    public void MapSubRecords(BinaryReader reader)
    {
        while (reader.BaseStream.Position < GetRecordEndPosition())
        {
            var id = (NavigationDataType)reader.ReadUInt16();

            BglRecord? record = id switch
            {
                NavigationDataType.Localizer => new LocalizerRecord(reader),
                NavigationDataType.GlideSlope => new GlideslopeRecord(reader),
                NavigationDataType.Dme => new DmeRecord(reader),
                NavigationDataType.Name => new NameRecord(reader),
                _ => null
            };
            
            if (record is not null) SubRecords.Add(record);
        }
    }
}