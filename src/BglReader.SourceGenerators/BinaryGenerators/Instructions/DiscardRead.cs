using System;

namespace BglReader.SourceGenerators.BinaryGenerators.Instructions;

internal sealed record DiscardRead(ConsumeLength Consumption) : ValueReadInstruction
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

internal abstract record ConsumeLength;
internal sealed record ConstantConsumeLength(int NumberOfBytes) : ConsumeLength;
internal sealed record ReferencedConsumeLength(string PropertyName) : ConsumeLength;