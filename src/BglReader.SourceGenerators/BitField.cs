using System.Collections.Generic;

public sealed record ClassModel<T>(
    string Name,
    string Namespace,
    bool IsInheriting,
    IReadOnlyList<T> Properties)
{
    public string UnderlyingType { get; init; }
}