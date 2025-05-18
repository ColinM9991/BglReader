namespace BglReader.Airport;

public class DeleteAirportRecord : BglRecord
{
    public DeleteAirportRecord(BinaryReader reader) : base(reader)
    {
        DeleteFlags = reader.ReadUInt16();
        NumberOfRunways = reader.ReadByte();
        NumberOfStarts = reader.ReadByte();
        NumberOfFrequencies = reader.ReadByte();

        reader.ReadBytes((NumberOfRunways * 4) + (NumberOfStarts * 4) + (NumberOfFrequencies * 4));
    }

    public ushort DeleteFlags { get; set; }

    public byte NumberOfRunways { get; set; }

    public byte NumberOfStarts { get; set; }

    public byte NumberOfFrequencies { get; set; }
}