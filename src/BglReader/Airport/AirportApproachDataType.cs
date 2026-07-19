namespace BglReader.Airport;

public enum AirportApproachDataType : ushort
{
    ApproachLegs = 0x002D,
    MissedApproachLegs = 0x002E,
    Transition = 0x002C,
    TransitionLegs = 0x002F,
}