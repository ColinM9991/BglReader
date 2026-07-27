using BglReader.Airport.Subsections.Types;
using BglReader.Generic;
using BglReader.ValueObjects;

namespace BglReader.Airport.Subsections;

public class DeleteAirportRecord : BglRecord
{
    public DeleteAirportRecord(ushort id, BglBinaryReader reader) : base(id, reader)
    {
        DeleteFlags = (DeleteFlags)reader.ReadUInt16();
        NumberOfRunways = reader.ReadByte();
        NumberOfStarts = reader.ReadByte();
        NumberOfFrequencies = reader.ReadByte();

        Runways = [.. MapRunways(reader)];
        Starts = [.. MapStarts(reader)];
        Frequencies = [.. MapFrequencies(reader)];

        _ = reader.ReadByte(); // Unused
    }

    public DeleteFlags DeleteFlags { get; }

    public byte NumberOfRunways { get; }

    public byte NumberOfStarts { get; }

    public byte NumberOfFrequencies { get; }

    public ICollection<DeleteRunway> Runways { get; }

    public ICollection<DeleteStart> Starts { get; }

    public ICollection<DeleteFrequency> Frequencies { get; }

    private IEnumerable<DeleteRunway> MapRunways(BglBinaryReader reader) => Enumerable.Range(0, NumberOfRunways)
        .Select(_ => new DeleteRunway(
            reader.ReadByte(),
            reader.ReadByte(),
            reader.ReadByte(),
            reader.ReadByte()));

    private IEnumerable<DeleteStart> MapStarts(BglBinaryReader reader) => Enumerable.Range(0, NumberOfStarts).Select(_ =>
        new DeleteStart(
            reader.ReadByte(),
            reader.ReadByte(),
            reader.ReadByte(),
            reader.ReadByte()));

    private IEnumerable<DeleteFrequency> MapFrequencies(BglBinaryReader reader) => Enumerable.Range(0, NumberOfFrequencies)
        .Select(x => new DeleteFrequency(reader.ReadUInt32()));
}