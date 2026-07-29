namespace BglReader.SourceGenerators.BinaryGenerators.Instructions;

public abstract record ReadInstruction
{
    public abstract void Emit(string propertyName, IndentingStringBuilder sb);
}