namespace BglReader.Scenery;

[Flags]
public enum LibraryObjectFlags
{
    AboveGroundLevel = 1,
    NoAutogenSuppression = 2,
    NoCrash = 4,
    NoFog = 8,
    NoShadow = 16,
    NoZWrite = 32,
    NoZTest = 64,
}