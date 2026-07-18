using System.Text;
using BglReader.Airport;

namespace BglReader;

public sealed class BglBinaryReader : IDisposable
{
    private readonly BinaryReader _reader;

    public BglBinaryReader(
        BinaryReader reader)
    {
        _reader = reader;
    }

    public long Position
    {
        get => _reader.BaseStream.Position;
        set => _reader.BaseStream.Position = value;
    }
    
    public void Seek(long position) => _reader.BaseStream.Seek(position, SeekOrigin.Begin);
    
    public byte ReadByte() => _reader.ReadByte();
    
    public ushort ReadUInt16() => _reader.ReadUInt16();
    
    public short ReadInt16() => _reader.ReadInt16();
    
    public uint ReadUInt32() => _reader.ReadUInt32();
    
    public int ReadInt32() => _reader.ReadInt32();
    
    public float ReadSingle() => _reader.ReadSingle();
    
    public byte[] ReadBytes(int count) => _reader.ReadBytes(count);

    public Coordinate ReadCoordinates(bool hasElevation = true) => hasElevation
        ? Coordinate.FromBgl(ReadInt32(), ReadInt32(), ReadInt32())
        : Coordinate.FromBgl(ReadInt32(), ReadInt32());

    public Triangle ReadTriangle() => new(ReadSingle(), ReadUInt16(), ReadUInt16());

    public string ReadString(int bytes) => Encoding.UTF8.GetString(ReadUntilNull(bytes));

    private byte[] ReadUntilNull(int count) => _reader.ReadBytes(count).TakeWhile(x => x != 0).ToArray();
    
    public void Dispose()
    {
        _reader.Dispose();
    }
}