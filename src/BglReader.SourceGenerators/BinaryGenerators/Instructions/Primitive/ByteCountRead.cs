using System;

namespace BglReader.SourceGenerators.BinaryGenerators.Instructions.Primitive;


internal sealed record ByteCountRead(ConsumeLength Consumption) : ValueReadInstruction
{
    internal override string EmitValue()
    {
        var numberOfBytes = Consumption switch
        {
            ConstantConsumeLength c => c.NumberOfBytes.ToString(),
            ReferencedConsumeLength r => r.PropertyName,
            _ => throw new InvalidOperationException(),
        };
        
        return $"reader.ReadBytes({numberOfBytes})";
    }
}

internal abstract record ByteStringRead : ValueReadInstruction;

internal sealed record FixedByteStringRead(ConsumeLength Consumption) : ByteStringRead
{
    internal override string EmitValue()
    {
        var numberOfBytes = Consumption switch
        {
            ConstantConsumeLength c => c.NumberOfBytes.ToString(),
            ReferencedConsumeLength r => r.PropertyName,
            _ => throw new InvalidOperationException(),
        };

        return $"reader.ReadString({numberOfBytes})";
    }
}

internal sealed record NullTerminatedStringRead(int Alignment) : ByteStringRead
{
    internal override string EmitValue() => $"reader.ReadNullTerminatedString({Alignment})";
}

internal abstract record ConsumeLength;
internal sealed record ConstantConsumeLength(int NumberOfBytes) : ConsumeLength;
internal sealed record ReferencedConsumeLength(string PropertyName) : ConsumeLength;