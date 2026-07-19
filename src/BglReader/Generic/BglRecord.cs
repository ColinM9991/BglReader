namespace BglReader.Generic;

/// <inheritdoc/>
public class BglRecord : BaseBglRecord<uint>
{
    protected BglRecord(BglBinaryReader reader, bool shouldRewindStream = true) : base(reader, shouldRewindStream)
    {
    }
}