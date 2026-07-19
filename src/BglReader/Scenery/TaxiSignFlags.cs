namespace BglReader.Scenery;

[Flags]
public enum TaxiSignFlags
{
    None = 0,
    IsAgl = 1,
    ClampPitch = 2,
    ClampBank = 4,
}