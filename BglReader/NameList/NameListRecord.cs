using System.Text;

namespace BglReader.NameList;

// TODO cleanup and consolidate collections
public class NameListRecord : BglRecord
{
    public NameListRecord(BinaryReader reader) : base(reader, false)
    {
        NumberOfRegionNames = reader.ReadUInt16();
        NumberOfCountryNames = reader.ReadUInt16();
        NumberOfStateNames = reader.ReadUInt16();
        NumberOfCityNames = reader.ReadUInt16();
        NumberOfAirportNames = reader.ReadUInt16();
        NumberOfIdentifiers = reader.ReadUInt16();

        var regionOffset = reader.ReadUInt32();
        var countryOffset = reader.ReadUInt32();
        var stateOffset = reader.ReadUInt32();
        var cityOffset = reader.ReadUInt32();
        var airportOffset = reader.ReadUInt32();
        var identifierOffset = reader.ReadUInt32();

        MapList(reader, NameListItemType.Region, regionOffset, countryOffset, NumberOfRegionNames);
        MapList(reader, NameListItemType.Country, countryOffset, stateOffset, NumberOfCountryNames);
        MapList(reader, NameListItemType.State, stateOffset, cityOffset, NumberOfStateNames);
        MapList(reader, NameListItemType.City, cityOffset, airportOffset, NumberOfCityNames);
        MapList(reader, NameListItemType.Airport, airportOffset, identifierOffset, NumberOfAirportNames);
        MapIcaoList(reader, identifierOffset, NumberOfIdentifiers);
    }

    public ushort NumberOfRegionNames { get; }

    public ushort NumberOfCountryNames { get; }

    public ushort NumberOfStateNames { get; }

    public ushort NumberOfCityNames { get; }

    public ushort NumberOfAirportNames { get; }

    public ushort NumberOfIdentifiers { get; }

    public IDictionary<NameListItemType, string[]> Names { get; } = new Dictionary<NameListItemType, string[]>();

    public ICollection<IcaoNameListItem> IcaoNames { get; } = new List<IcaoNameListItem>();

    private void MapList(BinaryReader reader,
        NameListItemType itemType,
        uint startOffset,
        uint endOffset,
        ushort numberOfRecords)
    {
        if (numberOfRecords == 0) return;

        reader.BaseStream.Position = GetRecordStartPosition() + startOffset;

        var size = endOffset - startOffset;

        var offsets = Enumerable.Range(0, numberOfRecords)
            .Select(x => (Offset: reader.ReadUInt32(), Index: x))
            .ToDictionary(x => x.Offset, x => x.Index);

        var remainingBytes = size - 4 * numberOfRecords;
        var bytes = reader.ReadBytes((int)remainingBytes).AsSpan();

        var orderedValues = offsets.Keys.Order().ToArray();

        var names = new string[offsets.Count];
        for (var i = 0; i < orderedValues.Length; i++)
        {
            var itemStartOffset = orderedValues[i];
            var itemEndOffset = i < orderedValues.Length - 1
                ? (int)orderedValues[i + 1]
                : bytes.Length;

            var nameString = Encoding.UTF8.GetString(bytes[(int)itemStartOffset..itemEndOffset]);

            names[offsets[itemStartOffset]] = nameString;
        }

        Names[itemType] = names;
    }

    private void MapIcaoList(BinaryReader reader, uint startOffset, ushort numberOfRecords)
    {
        if (numberOfRecords == 0) return;

        reader.BaseStream.Position = GetRecordStartPosition() + startOffset;

        for (var i = 0; i < numberOfRecords; i++)
        {
            IcaoNames.Add(new IcaoNameListItem(reader));
        }
    }
}