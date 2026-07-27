namespace BglReader.Generic;

/// <inheritdoc/>
public class BglRecord : BaseBglRecord<uint>
{
    protected BglRecord(ushort id, BglBinaryReader reader) : base(id, reader)
    {
    }
}