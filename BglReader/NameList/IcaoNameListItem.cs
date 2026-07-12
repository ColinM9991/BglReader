namespace BglReader.NameList;

public readonly struct IcaoNameListItem
{
    public IcaoNameListItem(
        BinaryReader reader)
    {
        RegionNameIndex = reader.ReadByte();
        CountryNameIndex = reader.ReadByte();
        StateNameIndex = reader.ReadUInt16() >> 4;
        CityNameIndex = reader.ReadUInt16();
        AirportNameIndex = reader.ReadUInt16();
        Identifier = new ShiftedIcaoIdentifier(reader.ReadUInt32());
        Region = new IcaoIdentifier(reader.ReadUInt32());
        Qmid = new Qmid(reader.ReadUInt16(), reader.ReadUInt16(), 9);
    }

    public byte RegionNameIndex { get; }

    public byte CountryNameIndex { get; }

    public int StateNameIndex { get; }

    public ushort CityNameIndex { get; }

    public ushort AirportNameIndex { get; }

    public ShiftedIcaoIdentifier Identifier { get; }

    public IcaoIdentifier Region { get; }

    public Qmid Qmid { get; }
}