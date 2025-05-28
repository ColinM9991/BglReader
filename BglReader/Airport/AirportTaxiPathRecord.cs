using BglReader.Generic;

namespace BglReader.Airport;

public class AirportTaxiPathRecord : BglRecord
{
    public AirportTaxiPathRecord(BinaryReader reader) : base(reader)
    {
        NumberOfPaths = reader.ReadUInt16();
        
        MapTaxiPaths(reader);
    }
    
    public ushort NumberOfPaths { get; }

    public ICollection<TaxiPath> Paths { get; } = new List<TaxiPath>();
    
    private void MapTaxiPaths(BinaryReader reader)
    {
        if (NumberOfPaths == 0) return;

        for (var path = 0; path < NumberOfPaths; path++)
        {
            Paths.Add(new TaxiPath(
                reader.ReadUInt16(),
                reader.ReadUInt16(),
                reader.ReadByte(),
                reader.ReadByte(),
                reader.ReadByte(),
                reader.ReadByte(),
                reader.ReadSingle(),
                reader.ReadSingle()));

            _ = reader.ReadBytes(4);
            _ = reader.ReadBytes(16);
            _ = reader.ReadBytes(4);
        }
    }
}