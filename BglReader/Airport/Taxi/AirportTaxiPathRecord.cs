using BglReader.Generic;

namespace BglReader.Airport.Taxi;

public class AirportTaxiPathRecord : BglRecord
{
    public AirportTaxiPathRecord(BinaryReader reader) : base(reader)
    {
        NumberOfPaths = reader.ReadUInt16();
        
        MapTaxiPaths(reader);
    }

    public AirportSubsectionDataType TaxiPathType => (AirportSubsectionDataType)Id;
    
    public ushort NumberOfPaths { get; }

    public ICollection<TaxiPath> Paths { get; } = new List<TaxiPath>();
    
    private void MapTaxiPaths(BinaryReader reader)
    {
        if (NumberOfPaths == 0) return;

        for (var path = 0; path < NumberOfPaths; path++)
        {
            var taxiPath =
                TaxiPathType is AirportSubsectionDataType.TaxiPathP3DV4 or AirportSubsectionDataType.TaxiPathP3DV5
                    ? new TaxiPathP3D(reader)
                    : new TaxiPath(reader);
            
            Paths.Add(taxiPath);
        }
    }
}