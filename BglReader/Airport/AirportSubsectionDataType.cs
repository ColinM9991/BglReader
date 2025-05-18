namespace BglReader.Airport;

public enum AirportSubsectionDataType : ushort
{
    Name = 0x0019,
    IncludedTowerSceneryObject = 0x0066,
    
    Runway = 0x0004,
    RunwayP3DV4 = 0x003E,
    
    Helipad = 0x0026,
    Start = 0x0011,
    Com = 0x0012,
    DeleteAirport = 0x0033,
    
    ApronFirst = 0x0037,
    ApronFirstP3DV5 = 0x00AF,
    ApronSecond = 0x0030,
    ApronSecondP3DV4 = 0x0041,
    ApronSecondP3DV5 = 0x00B0,
    
    ApronEdgeLights = 0x0031,
    
    TaxiwayPoint = 0x001A,
    TaxiwayPointP3DV5 = 0X00AC,
    
    TaxiwayParking = 0x003D,
    TaxiwayParkingP3DV5 = 0x00AD,
    TaxiwayParkingFS9 = 0x001B,
    
    TaxiPath = 0x001C,
    TaxiPathP3DV4 = 0x0040,
    TaxiPathP3DV5 = 0x00AE,
    
    TaxiName = 0x001D,
    
    Jetway = 0x003A,
    
    Approach = 0x0024,
    Waypoint = 0x0022,
    BlastFence = 0x0038,
    BoundaryFence = 0x0039,
    Unknown = 0x003B,
}