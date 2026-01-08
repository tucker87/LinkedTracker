using System.Collections.Generic;
using System.Linq;

namespace LinkedTracker.Data.Models;

public class Area(string name)
{
   public string Name { get; set; } = name;
   public List<Chest> Chests { get; set; } = new() { new() };
   public List<ItemType> RequiredItems { get; set; } = new();

   public bool IsLocked(List<ItemType> items) => RequiredItems.All(items.Contains);

   public bool IsDone => Chests.All(c => c.IsDone);

   public Area WithChests(int chestCount)
   {
      while (Chests.Count < chestCount)
         Chests.Add(new());

      return this;
   }

   public Area WithRequiredItems(params ItemType[] areas)
   {
      RequiredItems.AddRange(areas);

      return this;
   }
}

