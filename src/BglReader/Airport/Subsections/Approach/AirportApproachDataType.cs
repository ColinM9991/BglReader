namespace BglReader.Airport.Subsections.Approach;

public enum AirportApproachDataType : ushort
{
    ApproachLegs = 0x002D,
    MissedApproachLegs = 0x002E,
    Transition = 0x002C,
    TransitionV6 = 0x00B7,
    TransitionLegs = 0x002F,
}