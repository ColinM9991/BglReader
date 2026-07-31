using BglReader.Airport.Subsections.Types;
using BglReader.Generic;
using BglReader.Types;

namespace BglReader.Airport.Subsections.Apron;

// TODO Validate Apron types being used in P3DV5
public interface IAirportApronRecord
{
    SurfaceType SurfaceType { get; init; }
    
    Guid? MaterialSet { get; init; }
    
    Elevation Elevation { get; init; }

    ushort NumberOfVertices { get; init; }

    ICollection<Coordinate> Vertices { get; init; }
}