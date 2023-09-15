using System;
using System.Collections.Generic;
using System.Linq;
using LinkedTracker.Data.Models;

namespace LinkedTracker.Data.Repositories;

public class PointOfInterestRepository
{
    private readonly Dictionary<(string, string), Func<List<PointOfInterest>>> _poiGenerators;
    
    public PointOfInterestRepository()
    {
        _poiGenerators = new Dictionary<(string, string), Func<List<PointOfInterest>>>
        {
            [("lttp", "Randomizer")] = () => new() {
                new("Pedestal", 18, 20, new Area("Pedestal").WithRequiredItems(ItemType.Pendant1, ItemType.Pendant2, ItemType.Pendant3)),
                new("Lost Woods", 70, 50, new Area("Shroom"), new Area("Hideout")),
                new("Lumberjack Cave", 139, 21, new Area("Cave")),
                new("The Well", 20, 180, new Area("Cave").WithChests(4), new Area("Bomb")),
                new("Blind's House", 65, 180, new Area("Main").WithChests(4), new Area("Bomb")),
                new("Bottle Vendor", 40, 210, new Area("This Jerk")),
                new("Chicken House", 42, 234, new Area("Bombable Wall")),
                new("Sick Kid", 68, 232, new Area("By The Bed")),
                new("Tavern", 70, 255, new Area("Back Room")),
                new("Ether Tablet", 185, 9, new Area("Tablet")),
                new("Tower of Hera", 246, 18, new Area("Dungeon").WithChests(2)),
                new("Spectacle Rock", 214, 45, new Area("Cave"), new Area("Up On Top")),
                new("Floating Island", 358, 7, new Area("Island")),
                new("Floating Island", 358, 7, new Area("Island")),
                new("Spiral Cave", 350, 40, new Area("Cave")),
                new("Mimic Cave", 371, 40, new Area("Cave")),
                new("Paradox Cave", 378, 64, new Area("Top").WithChests(2), new Area("Bottom").WithChests(5)),
                //Also Paradox cave somehow... 381, 95
                new("Waterfall Fairy", 396, 66,new Area("Waterfall Cave").WithChests(2)),
                new("Zora Area", 423, 57, new Area("King"), new Area("Ledge")),
                new("Old Man", 179, 83, new Area("Bring Him Home")),
                new("Hyrule Castle & Sanctuary", 204, 119, new Area("Escape")),
                //Also Hyrule Castle & Sanctuary somehow... 220, 196
                new("Bonk Rocks", 172, 129, new Area("Cave")),
                new("Graveyard Ledge", 251, 121, new Area("Cave")),
                new("Kings Tomb", 265, 133, new Area("The Crypt")),
                new("Witch's Hut", 353, 147, new Area("Assistant")),
                new("Sahasrala's Hut", 358, 200, new Area("Back Room").WithChests(3), new Area("Shabadoo")),
                new("Eastern Palace", 423, 172, new Area("Dungeon").WithChests(3)),
                new("Dwarven Smiths", 135, 235, new Area("Bring Him Home")),
                new("Magic Bat", 144, 249, new Area("Magic Bowl")),
                new("Race Game", 25, 303, new Area("Take This Trash")),
                new("Library", 69, 290, new Area("On The Shelf")),
                new("Grove Digging Spot", 130, 295, new Area("Hidden Treasure")),
                new("Desert Palace", 32, 354, new Area("Dungeon").WithChests(2)),
                new("Desert Ledge", 9, 405, new Area("Ledge")),
                new("Checkerboard Cave", 77, 343, new Area("Cave")),
                new("Aginah Cave", 88, 365, new Area("Cave")),
                new("Bombos Tablet", 97, 407, new Area("Tablet")),
                new("Purple Chest", 150, 396, new Area("Show To Gary")),
                new("Dam", 207, 413, new Area("Inside"), new Area("Outside")),
                new("Purple Chest", 150, 396, new Area("Show To Gary")),
                new("Link's House", 242, 304, new Area("By The Door")),
                new("Mini Moldorm Cave", 288, 414, new Area("Cave").WithChests(5)),
                new("Lake Hylia Island", 319, 367, new Area("Island")),
                new("Ice Rod Cave", 394, 342, new Area("Cave")),
                new("Hobo", 305, 305, new Area("Under The Bridge")),
                new("Castle Secret Entrance", 263, 183, new Area("Uncle"), new Area("Hallway")),
                new("South of Grove", 120, 371, new Area("Circle Of Bushes")),
                
                
                //Dark World
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