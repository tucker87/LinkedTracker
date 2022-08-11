using System.Collections.Generic;
using System.Linq;

namespace LinkedTracker.Data.Models;

public class Area
{
    public Area(string name, int chestCount = 1)
    {
        Name = name;
        Chests = Enumerable.Range(0, chestCount).Select(_ => new Chest()).ToList();
    }
    
    public string Name { get; set; }
    public List<Chest> Chests { get; set; }
    public bool IsDone => Chests.All(c => c.IsDone);
}