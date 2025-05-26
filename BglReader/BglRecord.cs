namespace BglReader;

public class BglRecord : BglNode
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

    protected const int HeaderSize = 6;
    
    public ushort Id { get; }

    public uint Size { get; }
    
    protected long GetRecordStartPosition() => _recordStreamPosition;

    protected long GetRecordEndPosition() => _recordStreamPosition + Size;
}