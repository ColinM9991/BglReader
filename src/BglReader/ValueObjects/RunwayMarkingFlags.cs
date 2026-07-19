using BglReader.Attributes;

namespace BglReader.ValueObjects;

[Flags]
public enum RunwayMarkingFlags : ushort
{
    None                    = 0,
    Edges                   = 1 << 0,
    Threshold               = 1 << 1,
    FixedDistance           = 1 << 2,
    Touchdown               = 1 << 3,
    Dashes                  = 1 << 4,
    Ident                   = 1 << 5,
    Precision               = 1 << 6,
    EdgePavement            = 1 << 7,
    SingleEnd               = 1 << 8,
    PrimaryClosed           = 1 << 9,
    SecondaryClosed         = 1 << 10,
    PrimaryStol             = 1 << 11,
    SecondaryStol           = 1 << 12,
    AlternateThreshold      = 1 << 13,
    AlternateFixedDistance  = 1 << 14,
    AlternateTouchdown      = 1 << 15
}