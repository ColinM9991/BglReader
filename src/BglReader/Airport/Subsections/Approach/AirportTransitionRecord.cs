using BglReader.Airport.Subsections.Types;
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

        (FixType, FixIdentifier) = (AirportApproachDataType)Id == AirportApproachDataType.TransitionV6
            ? ReadV6FixFlags(reader)
            : ReadPackedFixFlags(reader);
        FixRegionFlags = new RegionIdentifierFlags(reader.ReadUInt32());

        Altitude = reader.ReadSingle();

        if (Type == TransitionType.Dme)
        {
            DmeIdent = new ShiftedIcaoIdentifier(reader.ReadUInt32());

            DmeRegionFlags = new RegionIdentifierFlags(reader.ReadUInt32());

            Radial = reader.ReadUInt32();
            Distance = reader.ReadSingle();
        }

        LegRecord = NumberOfTransitionLegs > 0
            ? new AirportLegBaseRecord(reader)
            : null;
    }

    public TransitionType Type { get; }

    public byte NumberOfTransitionLegs { get; }

    public FixType FixType { get; }

    public IcaoIdentifier FixIdentifier { get; }

    public RegionIdentifierFlags FixRegionFlags { get; }

    public float Altitude { get; }

    public ShiftedIcaoIdentifier? DmeIdent { get; }

    public RegionIdentifierFlags? DmeRegionFlags { get; }

    public uint Radial { get; }

    public float Distance { get; }

    public AirportLegBaseRecord? LegRecord { get; }

    private static (FixType FixType, IcaoIdentifier IcaoIdentifier) ReadV6FixFlags(BglBinaryReader reader) =>
        ((FixType)reader.ReadUInt32(), new IcaoIdentifier(reader.ReadUInt32()));

    private static (FixType FixType, IcaoIdentifier IcaoIdentifier) ReadPackedFixFlags(BglBinaryReader reader)
    {
        var fixFlags = new FixFlags(reader.ReadUInt32());
        return (fixFlags.Type, fixFlags.Identifier);
    }
}