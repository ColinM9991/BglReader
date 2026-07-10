using Microsoft.CodeAnalysis;

public sealed record Property(
    string Type,
    SpecialType ReturnKind, 
    string Name,
    int Offset,
    int Length);