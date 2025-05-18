using System.Text;

namespace BglReader.Airport;

public readonly struct TaxiParking
{
    public TaxiParking(BinaryReader reader)
    {
        Info = reader.ReadUInt32();
        Radius = reader.ReadSingle();
        Heading = reader.ReadSingle();
        TeeOffset = reader.ReadSingle();
        TeeOffset2 = reader.ReadSingle();
        TeeOffset3 = reader.ReadSingle();
        TeeOffset4 = reader.ReadSingle();
        Coordinate = new Coordinate(reader.ReadInt32(), reader.ReadInt32());

        MapAirlineDesignators(reader);
        
        _ = reader.ReadBytes(4);
    }

    public uint Info { get; }

    public float Radius { get; }

    public float Heading { get; }

    public float TeeOffset { get; }

    public float TeeOffset2 { get; }

    public float TeeOffset3 { get; }

    public float TeeOffset4 { get; }

    public uint CountOfAirlineCodes => (Info >> 24) & 0xFF;

    public Coordinate Coordinate { get; }

    public ICollection<string> AirlineDesignators { get; } = new List<string>();

    public void MapAirlineDesignators(BinaryReader reader)
    {
        if (CountOfAirlineCodes == 0) return;

        for (var airlineCode = 0; airlineCode < CountOfAirlineCodes; airlineCode++)
        {
            AirlineDesignators.Add(Encoding.UTF8.GetString(reader.ReadBytes(4)));
        }
    }
}