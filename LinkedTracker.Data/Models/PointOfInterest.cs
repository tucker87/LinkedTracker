using System.Collections.Generic;
using System.Linq;

namespace LinkedTracker.Data.Models;

public class PointOfInterest : IIndexed
{
    public PointOfInterest(string name, int x, int y, params Area[] areas)
    {
        Name = name;
        X = x;
        Y = y;
        Areas = areas.ToList();
    }
    public int Index { get; set; }
    public string Name { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public List<Area> Areas { get; set; }
    public bool IsDone => Areas.All(a => a.IsDone);
}