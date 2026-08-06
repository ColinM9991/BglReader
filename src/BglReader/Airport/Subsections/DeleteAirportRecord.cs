using BglReader.Airport.Subsections.Types;
using BglReader.Generic;
using BglReader.ValueObjects;

namespace BglReader.Airport.Subsections;

[BinarySerializable]
public partial class DeleteAirportRecord : BglRecord
{
    [Binary(1)]
    public DeleteFlags DeleteFlags { get; }

    [Binary(2)]
    public byte NumberOfRunways { get; }

    [Binary(3)]
    public byte NumberOfStarts { get; }

    [Binary(4)]
    public byte NumberOfFrequencies { get; }

    [Binary(5)]
    [BinaryCollection(nameof(NumberOfRunways))]
    public ICollection<DeleteRunway> Runways { get; }

    [Binary(6)]
    [BinaryCollection(nameof(NumberOfStarts))]
    public ICollection<DeleteStart> Starts { get; }

    [Binary(7)]
    [BinaryCollection(nameof(NumberOfFrequencies))]
    public ICollection<DeleteFrequency> Frequencies { get; }
    
    [Binary(8)]
    public byte Unknown { get; }
}