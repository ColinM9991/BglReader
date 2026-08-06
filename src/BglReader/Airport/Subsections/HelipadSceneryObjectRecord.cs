using BglReader.Scenery.LibraryObjects;

namespace BglReader.Airport.Subsections;

public sealed class HelipadSceneryObjectRecord(ushort id, BglBinaryReader reader) : IncludedSceneryObject(id, reader);