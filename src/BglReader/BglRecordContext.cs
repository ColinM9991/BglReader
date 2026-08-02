using BglReader.Generic;

namespace BglReader;

public record BglRecordContext(ushort RecordId, BaseBglRecord ParentRecord);