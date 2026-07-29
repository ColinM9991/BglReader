namespace BglReader.SourceGenerators.BinaryGenerators.Instructions;

internal sealed record PolymorphicCollectionRead(string FactoryTypeName, string IdTypeName) : ReadInstruction
{
    public override void Emit(string propertyName, IndentingStringBuilder sb)
    {
        sb.AppendLine("while (reader.Position < EndPosition)")
            .AppendLine("{")
            .IncrementIndentation()
            .AppendLine("var recordId = reader.ReadUInt16();")
            .AppendLine($"var record = {FactoryTypeName}.Create(({IdTypeName})recordId, reader);")
            .AppendLine()
            .AppendLine("if (record is null) continue;")
            .AppendLine($"{propertyName}.Add(record);")
            .DecrementIndentation()
            .AppendLine("}");
    }
}