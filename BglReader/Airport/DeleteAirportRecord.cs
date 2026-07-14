using BglReader.Generic;
using BglReader.ValueObjects;

namespace BglReader.Airport;

public class DeleteAirportRecord : BglRecord
{
    public DeleteAirportRecord(BinaryReader reader) : base(reader)
    {
        DeleteFlags = (DeleteFlags)reader.ReadUInt16();
        NumberOfRunways = reader.ReadByte();
        NumberOfStarts = reader.ReadByte();
        NumberOfFrequencies = reader.ReadByte();

        Runways = MapRunways(reader).ToList();
        Starts = MapStarts(reader).ToList();
        Frequencies = MapFrequencies(reader).ToList();

        _ = reader.ReadByte(); // Unused
    }

    public ValueObjects.DeleteFlags DeleteFlags { get; }

    public byte NumberOfRunways { get; }

    public byte NumberOfStarts { get; }

    public byte NumberOfFrequencies { get; }

    public ICollection<DeleteRunway> Runways { get; }

    public ICollection<DeleteStart> Starts { get; }

    public ICollection<DeleteFrequency> Frequencies { get; }

    private IEnumerable<DeleteRunway> MapRunways(BinaryReader reader) => Enumerable.Range(0, NumberOfRunways)
        .Select(_ => new DeleteRunway(
            reader.ReadByte(),
            reader.ReadByte(),
            reader.ReadByte(),
            reader.ReadByte()));

    private IEnumerable<DeleteStart> MapStarts(BinaryReader reader) => Enumerable.Range(0, NumberOfStarts).Select(x =>
        new DeleteStart(
            reader.ReadByte(),
            reader.ReadByte(),
            reader.ReadByte(),
            reader.ReadByte()));

    private IEnumerable<DeleteFrequency> MapFrequencies(BinaryReader reader) => Enumerable.Range(0, NumberOfFrequencies)
        .Select(x => new DeleteFrequency(reader.ReadUInt32()));
}