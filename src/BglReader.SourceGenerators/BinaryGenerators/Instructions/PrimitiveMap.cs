using System.Collections.Generic;
using BglReader.SourceGenerators.BinaryGenerators.Instructions.Primitive;
using Microsoft.CodeAnalysis;

namespace BglReader.SourceGenerators.BinaryGenerators.Instructions;

internal static class PrimitiveMap
{
    internal static readonly IReadOnlyDictionary<SpecialType, PrimitiveRead> Types =
        new Dictionary<SpecialType, PrimitiveRead>
        {
            [SpecialType.System_Byte] = new(SpecialType.System_Byte),
            [SpecialType.System_Int16] = new(SpecialType.System_Int16),
            [SpecialType.System_UInt16] = new(SpecialType.System_UInt16),
            [SpecialType.System_Int32] = new(SpecialType.System_Int32),
            [SpecialType.System_UInt32] = new(SpecialType.System_UInt32),
            [SpecialType.System_Single] = new(SpecialType.System_Single),
            [SpecialType.System_Double] = new(SpecialType.System_Double),
        };
    internal static readonly IReadOnlyDictionary<SpecialType, string> Readers =
        new Dictionary<SpecialType, string>
        {
            [SpecialType.System_Byte] = "reader.ReadByte()",
            [SpecialType.System_Int16] = "reader.ReadInt16()",
            [SpecialType.System_UInt16] = "reader.ReadUInt16()",
            [SpecialType.System_Int32] = "reader.ReadInt32()",
            [SpecialType.System_UInt32] = "reader.ReadUInt32()",
            [SpecialType.System_Single] = "reader.ReadSingle()",
            [SpecialType.System_Double] = "reader.ReadDouble()",
        };
}