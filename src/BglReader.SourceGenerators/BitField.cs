public sealed record BitField(
    string Name,
    bool IsInheriting,
    string Namespace,
    string UnderlyingType,
    Property[] Properties);