using BglReader.Generic;
using BglReader.Types;
using BglReader.ValueObjects.BitFields;

namespace BglReader.Airport.Subsections.Approach;

public class AirportTransitionRecord : BglRecord
{
    public AirportTransitionRecord(ushort id, BglBinaryReader reader) : base(id, reader)
    {
        Type = (TransitionType)reader.ReadByte();
        NumberOfTransitionLegs = reader.ReadByte();
        
        FixFlags = new FixFlags(reader.ReadUInt32());
        FixRegionFlags = new RegionIdentifierFlags(reader.ReadUInt32());
        
        Altitude = reader.ReadSingle();

        if (Type == TransitionType.Dme)
        {
            DmeIdent = new ShiftedIcaoIdentifier(reader.ReadUInt32());
            
            DmeRegionFlags = new RegionIdentifierFlags(reader.ReadUInt32());
            
            Radial = reader.ReadUInt32();
            Distance = reader.ReadSingle();
        }
        
        LegRecord = new AirportLegBaseRecord((ushort)AirportApproachDataType.TransitionLegs, reader);
    }

    public TransitionType Type { get; }
    
    public byte NumberOfTransitionLegs { get; }
    
    public FixFlags FixFlags { get; }
    
    public RegionIdentifierFlags FixRegionFlags { get; }
    
    public float Altitude { get; }
    
    public ShiftedIcaoIdentifier? DmeIdent { get; }
    
    public RegionIdentifierFlags? DmeRegionFlags { get; }
    
    public uint Radial { get; }
    
    public float Distance { get; }
    
    public AirportLegBaseRecord LegRecord { get; }
}