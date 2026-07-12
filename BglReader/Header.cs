namespace BglReader;

public class Header
{
    public Header(BinaryReader reader)
    {
        var magicNumber = reader.ReadBytes(4);

        Size = reader.ReadUInt32();
        DateTime = new BglDateTime(reader.ReadUInt32(), reader.ReadUInt32());
        MagicNumber = new MagicNumber(magicNumber, reader.ReadBytes(4));
        NumberOfSections = reader.ReadUInt32();

        MapQmids(reader);
    }

    private void MapQmids(BinaryReader reader)
    {
        ReadOnlySpan<byte> bytes = reader.ReadBytes(32);

        for (var i = 0; i < 8; i++)
        {
            var value = BitConverter.ToUInt32(bytes[(i * 4)..]);

            if (value == 0)
                break;

            Qmids[i] = new Qmid(value);
        }
    }

    public MagicNumber MagicNumber { get; }
    
    public uint Size { get; }
    
    public BglDateTime DateTime { get; }
    
    public uint NumberOfSections { get; }
    
    public Qmid[] Qmids { get; } = new Qmid[8];
}