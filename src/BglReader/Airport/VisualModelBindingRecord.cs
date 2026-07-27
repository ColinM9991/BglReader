using BglReader.Generic;

namespace BglReader.Airport;

public sealed class VisualModelBindingRecord : BglRecord
{
    public VisualModelBindingRecord(ushort id, BglBinaryReader reader) : base(id, reader)
    {
        _ = reader.ReadBytes(2); // TODO Unknown
        Type = (VisualModelBindingType)reader.ReadUInt32();
        ModelId = new Guid(reader.ReadBytes(16));
    }
    
    public VisualModelBindingType Type { get; }
    
    public Guid ModelId { get; }
}

public enum VisualModelBindingType
{
    Approach1Red = 0x001D,
    Approach1Strobe = 0x001E,
    Approach1White = 0x001F,
    Approach26White = 0x0020,
    Approach35Red = 0x0021,
    Approach35White = 0x0022,
    Approach45White = 0x0023,
    Approach52White = 0x0024,
    Approach53Red = 0x0025,
    Approach53White = 0x0026,
    Approach54White = 0x0027,
    Approach55Red = 0x0028,
    ApproachBase = 0x002D,
    ApproachBaseNoElec = 0x002E,
    ApproachInsetRed = 0x0029,
    ApproachInsetStrobe = 0x002A,
    ApproachInsetWhite = 0x002B,
    ApproachStrobeFixture = 0x002C,
    ApronEdge = 0x0001,
    Odal = 0x002F,
    OdalInset = 0x0030,
    Reil = 0x0031,
    RunwayCenterWhiteRed = 0x0006,
    RunwayCenterWhiteWhite = 0x0007,
    RunwayEdgeInsetWhiteRed = 0x0008,
    RunwayEdgeInsetWhiteWhite = 0x0009,
    RunwayEdgeInsetWhiteYellow = 0x000A,
    RunwayEdgeInsetYellowRed = 0x000B,
    RunwayEdgeShortWhiteRed = 0x000C,
    RunwayEdgeShortWhiteWhite = 0x000D,
    RunwayEdgeShortWhiteYellow = 0x000E,
    RunwayEdgeShortYellowRed = 0x000F,
    RunwayEndInsetGreen = 0x0010,
    RunwayEndInsetGreenRed = 0x0011,
    RunwayEndInsetGreenWhite = 0x0012,
    RunwayEndInsetGreenYellow = 0x0013,
    RunwayEndInsetRedRed = 0x0014,
    RunwayEndShortGreen = 0x0015,
    RunwayEndShortGreenRed = 0x0016,
    RunwayEndShortGreenWhite = 0x0017,
    RunwayEndShortGreenYellow = 0x0018,
    RunwayEndShortRedRed = 0x0019,
    RunwayThresholdInsetGreen = 0x001A,
    RunwayThresholdShortGreen = 0x001B,
    RunwayTouchdown = 0x001C,
    TaxiwayCenterStraight = 0x0004,
    TaxiwayCenterCurve = 0x0005,
    TaxiwayEdge = 0x0002,
    TaxiwaySignLeg = 0x0034,
    TaxiwaySignPlate = 0x0035,
    Vasi = 0x0033,
}