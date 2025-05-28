using BglReader.Generic;

namespace BglReader.Airport;

public class AirportTransitionRecord : BglRecord
{
    public AirportTransitionRecord(BinaryReader reader) : base(reader)
    {
        Type = (TransitionType)reader.ReadByte();
        NumberOfTransitionLegs = reader.ReadByte();
        
        var fixFlags = reader.ReadUInt32();
        var regionFlags = reader.ReadUInt32();

        FixType = (FixType)(fixFlags & 0xF);
        FixIdentifier = IcaoIdentifier.Parse((fixFlags >> 5) & 0x7FFFFFF);
        FixRegion = IcaoIdentifier.Parse(regionFlags & 0x7FF);
        FixAirport = IcaoIdentifier.Parse((regionFlags >> 11) & 0x1FFFFF);
        
        Altitude = reader.ReadSingle();

        if (Type == TransitionType.Dme)
        {
            DmeIdent = IcaoIdentifier.Parse(reader.ReadUInt32(), true);
            
            var dmeRegionFlags = reader.ReadUInt32();
            
            DmeRegion = IcaoIdentifier.Parse(dmeRegionFlags & 0x7FF);
            DmeAirport = IcaoIdentifier.Parse((dmeRegionFlags >> 11) & 0x1FFFFF);
            
            Radial = reader.ReadUInt32();
            Distance = reader.ReadSingle();
        }
        
        LegRecord = new AirportLegBaseRecord(reader, false);
    }

    public TransitionType Type { get; }
    
    public byte NumberOfTransitionLegs { get; }
    
    public FixType FixType { get; }
    
    public IcaoIdentifier FixIdentifier { get; }
    
    public IcaoIdentifier FixRegion { get; }
    
    public IcaoIdentifier FixAirport { get; }
    
    public float Altitude { get; }
    
    public IcaoIdentifier DmeIdent { get; }
    
    public IcaoIdentifier DmeRegion { get; }
    
    public IcaoIdentifier DmeAirport { get; }
    
    public uint Radial { get; }
    
    public float Distance { get; }
    
    public AirportLegBaseRecord LegRecord { get; }
}