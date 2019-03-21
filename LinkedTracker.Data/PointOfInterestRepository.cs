using System.Collections.Generic;
using LinkedTracker.Data;

public interface IPointOfInterestRepository : IRepository<(string, string), List<PointOfInterest>>
{
    
}

public class PointOfInterestRepository : Repository<(string, string), List<PointOfInterest>>, IPointOfInterestRepository
{
    public PointOfInterestRepository()
    {
        Data = new Dictionary<(string, string), List<PointOfInterest>>
        {
            [("lttp", "Randomizer")] = new List<PointOfInterest>{
                new PointOfInterest(0, 0),
                new PointOfInterest(100, 100),
                new PointOfInterest(200, 200),
                new PointOfInterest(200, 800),
            }
        };
    }
}