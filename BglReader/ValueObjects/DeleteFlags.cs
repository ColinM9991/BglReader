using BglReader.Attributes;

namespace BglReader.ValueObjects;

[Flags]
public enum DeleteFlags : ushort
{
    None             = 0,
    AllApproaches    = 1 << 0,
    AllApronLights   = 1 << 1,
    AllAprons        = 1 << 2,
    AllFrequencies   = 1 << 3,
    AllHelipads      = 1 << 4,
    AllRunways       = 1 << 5,
    AllStarts        = 1 << 6,
    AllTaxiways      = 1 << 7
}