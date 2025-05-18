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
        const int qmidSize = 4;
        var qmids = reader.ReadBytes(32).AsSpan();
        for (var i = 0; i < Qmids.Length; i += qmidSize)
        {
            Qmids[i] = new Qmid(BitConverter.ToUInt32(qmids.Slice(i, 4)));
        }
    }

    public MagicNumber MagicNumber { get; set; }
    
    public uint Size { get; set; }
    
    public BglDateTime DateTime { get; set; }
    
    public uint NumberOfSections { get; set; }
    
    public Qmid[] Qmids { get; set; } = new Qmid[8];
}