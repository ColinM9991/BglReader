namespace BglReader.Scenery;

public enum SceneryObjectType
{
    TaxiSign = 0x000E,
    TaxiSignFS9 = 0x0005,
    TaxiSignP3D = 0x0013,
    
    LibraryObject = 0x000B,
    LibraryObjectFS9 = 0x0002,
    
    AttachedObject = 0x1002,
    Effect = 0x000D,
    GenericBuilding = 0x000A,
    ExtrusionBridge = 0x0012,
    Trigger = 0x0010,
}