using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using Microsoft.CodeAnalysis;

namespace BglReader.SourceGenerators;

internal sealed record ClassModel<T>
{
    public ClassModel(
        INamedTypeSymbol typeSymbol, 
        IReadOnlyList<T> properties)
    {
        Name = typeSymbol.Name;
        Type = typeSymbol.TypeKind;
        Namespace = typeSymbol.ContainingNamespace.ToDisplayString();
        IsInheriting = typeSymbol.BaseType is { SpecialType: not SpecialType.System_Object and not SpecialType.System_ValueType and not SpecialType.System_Enum };
        IsRecord = typeSymbol.IsRecord;
        IsReadOnly = typeSymbol.IsReadOnly;
        Properties = [.. properties];
    }
    
    public string Name { get; }
    
    public string Namespace { get; }
    
    public TypeKind Type { get; }
    
    public bool IsInheriting { get; }
    
    public bool IsRecord { get; }
    
    public bool IsReadOnly { get; }
    
    public string UnderlyingType { get; init; }
    
    public ImmutableArray<T> Properties { get; }

    public string ToDeclaration()
    {
        List<string> tokens = ["public"];
        
        if (IsReadOnly)
            tokens.Add("readonly");

        tokens.Add("partial");
        
        if (IsRecord)
            tokens.Add("record");
        
        var typeString = Type switch
        {
            TypeKind.Class => "class",
            TypeKind.Struct => "struct",
            _ => throw new ArgumentOutOfRangeException(nameof(Type)),
        };

        tokens.Add(typeString);
        tokens.Add(Name);
        
        return string.Join(" ", tokens);
    }
}