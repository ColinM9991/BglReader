using BglReader.Generic;
using BglReader.ValueObjects;

namespace BglReader.Airport;

public class AirportTransitionRecord : BglRecord
{
    public AirportTransitionRecord(BinaryReader reader) : base(reader)
    {
        Type = (TransitionType)reader.ReadByte();
        NumberOfTransitionLegs = reader.ReadByte();
        
        FixFlags = new FixFlags(reader.ReadUInt32());
        FixRegionFlagses = new RegionIdentifierFlags(reader.ReadUInt32());
        
        Altitude = reader.ReadSingle();

        if (Type == TransitionType.Dme)
        {
            DmeIdent = IcaoIdentifier.Parse(reader.ReadUInt32(), true);
            
            DmeRegionFlagses = new RegionIdentifierFlags(reader.ReadUInt32());
            
            Radial = reader.ReadUInt32();
            Distance = reader.ReadSingle();
        }
        
        LegRecord = new AirportLegBaseRecord(reader, false);
    }

    public TransitionType Type { get; }
    
    public byte NumberOfTransitionLegs { get; }
    
    public FixFlags FixFlags { get; }
    
    public RegionFlags FixRegionFlagses { get; }
    
    public float Altitude { get; }
    
    public IcaoIdentifier DmeIdent { get; }
    
    public RegionFlags DmeRegionFlagses { get; }
    
    public uint Radial { get; }
    
    public float Distance { get; }
    
    public AirportLegBaseRecord LegRecord { get; }
}