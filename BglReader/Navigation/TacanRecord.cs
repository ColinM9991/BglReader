using BglReader.Generic;

namespace BglReader.Navigation;

public class TacanRecord : BglRecord
{
    public TacanRecord(BinaryReader reader) : base(reader, false)
    {
        Coordinates = new Coordinate(reader.ReadInt32(), reader.ReadInt32(), reader.ReadInt32());
        Channel = reader.ReadUInt32();

        var infoFlags = reader.ReadByte();

        Band = (TacanBand)(infoFlags & 0x1);
        IsDmeOnly = (infoFlags & 0x2) == 0;
        Range = reader.ReadSingle();
        MagneticVariation = (MagneticVariation)reader.ReadSingle();
        Identifier = IcaoIdentifier.Parse(reader.ReadUInt32(), true);

        var regionFlags = reader.ReadUInt32();
        
        Region = IcaoIdentifier.Parse(regionFlags & 0x7FF);
        MapSubRecords(reader);
    }
    
    public Coordinate Coordinates { get; }
    
    public uint Channel { get; }
    
    public TacanBand Band { get; }
    
    public bool IsDmeOnly { get; }
    
    public float Range { get; }
    
    public MagneticVariation MagneticVariation { get; }
    
    public IcaoIdentifier Identifier { get; }
    
    public IcaoIdentifier Region { get; }
    
    public ICollection<BglRecord> SubRecords { get; } = new List<BglRecord>();
    
    public void MapSubRecords(BinaryReader reader)
    {
        var recordSize = GetRecordEndPosition();

        while (reader.BaseStream.Position < recordSize)
        {
            var id = (NavigationDataType)reader.ReadUInt16();

            BglRecord? record = id switch
            {
                NavigationDataType.Dme => new DmeRecord(reader),
                NavigationDataType.Name => new NameRecord(reader),
                _ => null
            };
            
            if (record is not null) SubRecords.Add(record);
        }
    }
}