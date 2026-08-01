using BglReader.Airport.Subsections.Types;
using BglReader.ValueObjects.BitFields;

namespace BglReader.Airport.Subsections.Taxi;

public interface ITaxiPath
{
    ushort StartIndex { get; }
    
    TaxiPathFlags PathFlags { get; }
    
    SurfacePointFlags TypeFlags { get; }
    
    /// <summary>
    /// Runway number if this is for a runway path. Otherwise it's the index to the taxi name.
    /// </summary>
    byte PathValue { get; }
    
    SurfaceLineFlags EdgeFlags { get; }
    
    SurfaceType Surface { get; }
    
    float Width { get; }
    
    int WeightLimit { get; }
}