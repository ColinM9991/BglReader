namespace BglReader.Airport;

public enum FixType
{
    Ndb                                 = 0x0003,
    TerminalNdb                        = 0x0004,
    TerminalWaypoint                   = 0x0006,
    Vor                                 = 0x0002,
    Waypoint                            = 0x0005,
    Runway                              = 0x0009,
    CourseToAlt                       = 0x000C,
    CourseToDist                      = 0x000D,
    HeadingToAlt                      = 0x000E,
    ManualTermination                  = 0x000B,
}