using System.Text;
using BglReader.Airport;

namespace BglReader;

public sealed class BglBinaryReader(BinaryReader reader) : IDisposable
{
    public long Position
    {
        get => reader.BaseStream.Position;
        set => reader.BaseStream.Position = value;
    }

    public byte Peek()
    {
        var position = Position;
        var nextByte = reader.ReadByte();

        Seek(position);
        return nextByte;
    }
    
    public void Seek(long position) => reader.BaseStream.Seek(position, SeekOrigin.Begin);
    
    public byte ReadByte() => reader.ReadByte();
    
    public ushort ReadUInt16() => reader.ReadUInt16();
    
    public short ReadInt16() => reader.ReadInt16();
    
    public uint ReadUInt32() => reader.ReadUInt32();
    
    public int ReadInt32() => reader.ReadInt32();
    
    public float ReadSingle() => reader.ReadSingle();
    
    public byte[] ReadBytes(int count) => reader.ReadBytes(count);

    public Coordinate ReadCoordinates(bool hasElevation = true) => hasElevation
        ? Coordinate.FromBgl(ReadInt32(), ReadInt32(), ReadInt32())
        : Coordinate.FromBgl(ReadInt32(), ReadInt32());

    public Triangle ReadTriangle(bool isP3DTriangle = true) => new(isP3DTriangle ? ReadSingle() : ReadUInt16(), ReadUInt16(), ReadUInt16());

    public string ReadString(int bytes) => Encoding.UTF8.GetString(ReadUntilNull(bytes));

    public byte[] ReadUntilNull(int count) => reader.ReadBytes(count).TakeWhile(x => x != 0).ToArray();
    
    public byte[] ReadUntilNull()
    {
        Span<byte> buffer = stackalloc byte[64];
        var length = 0;

        byte b;
        while ((b = reader.ReadByte()) != 0)
        {
            buffer[length++] = b;
        }

        return buffer[..length].ToArray();
    }
    
    public void Dispose()
    {
        reader.Dispose();
    }
}