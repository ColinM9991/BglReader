namespace BglReader;

public class BglRecord
{
    private readonly long _recordStreamPosition;
    
    public BglRecord(
        BinaryReader reader,
        bool rewindStream = true)
    {
        if (rewindStream)
            reader.BaseStream.Position -= 2L;
        
        _recordStreamPosition = reader.BaseStream.Position;

        Id = reader.ReadUInt16();
        Size = reader.ReadUInt32();
    }
    
    public ushort Id { get; }

    public uint Size { get; }
    
    protected long GetRecordStreamPosition() => _recordStreamPosition;

    protected long GetRecordEndPosition() => _recordStreamPosition + Size;
}