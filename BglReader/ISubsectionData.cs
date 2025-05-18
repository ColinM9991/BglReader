namespace BglReader;

public interface ISubsectionData
{
    static abstract ISubsectionData Create(BinaryReader reader, long iterationPosition);
}