using BglReader.Airport.Subsections.Types;
using BglReader.Generic;
using BglReader.Types;

namespace BglReader.Airport.Subsections.Apron;

// TODO Validate Apron types being used in P3DV5
public interface IAirportApronRecord
{
    SurfaceType SurfaceType { get; }
    
    Guid? MaterialSet { get; }
    
    Elevation Elevation { get; }

    ushort NumberOfVertices { get; }

    ICollection<Coordinate> Vertices { get; }
}