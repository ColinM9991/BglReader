namespace BglReader.Airport;

// TODO Flags
public class DeleteAirportRecord : BglRecord
{
    public DeleteAirportRecord(BinaryReader reader) : base(reader)
    {
        DeleteFlags = reader.ReadUInt16();
        NumberOfRunways = reader.ReadByte();
        NumberOfStarts = reader.ReadByte();
        NumberOfFrequencies = reader.ReadByte();

        MapRunways(reader);
        MapStarts(reader);
        MapFrequencies(reader);

        _ = reader.ReadByte(); // Unused
    }

    public ushort DeleteFlags { get; }

    public byte NumberOfRunways { get; }

    public byte NumberOfStarts { get; }

    public byte NumberOfFrequencies { get; }

    public ICollection<DeleteRunway> Runways { get; } = new List<DeleteRunway>();

    public ICollection<DeleteStart> Starts { get; } = new List<DeleteStart>();

    public ICollection<DeleteFrequency> Frequencies { get; } = new List<DeleteFrequency>();

    private void MapRunways(BinaryReader reader)
    {
        if (NumberOfRunways == 0) return;

        for (var i = 0; i < NumberOfRunways; i++)
        {
            Runways.Add(new DeleteRunway(
                reader.ReadByte(),
                reader.ReadByte(),
                reader.ReadByte(),
                reader.ReadByte()));
        }
    }

    private void MapStarts(BinaryReader reader)
    {
        if (NumberOfStarts == 0) return;

        for (var i = 0; i < NumberOfStarts; i++)
        {
            Starts.Add(new DeleteStart(
                reader.ReadByte(),
                reader.ReadByte(),
                reader.ReadByte()));

            _ = reader.ReadByte(); // TODO validate unused
        }
    }

    private void MapFrequencies(BinaryReader reader)
    {
        if (NumberOfFrequencies == 0) return;

        for (var i = 0; i < NumberOfFrequencies; i++)
        {
            Frequencies.Add(new DeleteFrequency(reader.ReadUInt32()));
        }
    }
}