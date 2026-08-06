namespace BglReader.Generic;

/// <inheritdoc/>
public class BglRecord : SizedBglRecord<uint>
{
    protected BglRecord(ushort id, BglBinaryReader reader) : base(id, reader)
    {
    }
}