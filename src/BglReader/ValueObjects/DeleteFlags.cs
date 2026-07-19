using BglReader.Attributes;

namespace BglReader.ValueObjects;

[Flags]
public enum DeleteFlags : ushort
{
    None             = 0,
    AllApproaches    = 1,
    AllApronLights   = 2,
    AllAprons        = 4,
    AllFrequencies   = 8,
    AllHelipads      = 16,
    AllRunways       = 32,
    AllStarts        = 64,
    AllTaxiways      = 128
}