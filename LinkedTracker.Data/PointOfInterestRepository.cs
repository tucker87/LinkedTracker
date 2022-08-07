using System;
using System.Collections.Generic;
using System.Linq;
using LinkedTracker.Data.Models;

namespace LinkedTracker.Data;

public interface IPointOfInterestRepository
{
    IEnumerable<PointOfInterest> Get((string game, string poiType) key);
}

public class PointOfInterestRepository : IPointOfInterestRepository
{
    private readonly Dictionary<(string, string), Func<List<PointOfInterest>>> _poiGenerators;
    
    public PointOfInterestRepository()
    {
        _poiGenerators = new Dictionary<(string, string), Func<List<PointOfInterest>>>
        {
            [("lttp", "Randomizer")] = () => new List<PointOfInterest> {
                new(0, 0),
                new(100, 100),
                new(200, 200),
                new(200, 800),
            }
        };
    }
    
    public IEnumerable<PointOfInterest> Get((string, string) key)
    {
        var pois = _poiGenerators[key]();
        
        //Add indexes to points;
        foreach (var (p, i) in pois.Select((p, i) => (p, i)))
            p.Index = i;

        return pois;
    }
}