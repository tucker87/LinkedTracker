using System;
using System.Collections.Generic;
using LinkedTracker.Data.Models;

public class ItemRepository 
{
    private Dictionary<(string, string), Func<List<Item>>> _itemGenerators;

    public ItemRepository()
    {
        _itemGenerators = new () {
            [("lttp", "Randomizer")] = () => new List<Item> {
                new(ItemType.Armor1),
                new(ItemType.Armor2),
                new(ItemType.Armor3),
                new(ItemType.Hookshot),
                new(ItemType.Boomerang1),
                new(ItemType.Boomerang2)
            }
        };
    }

    public List<Item> Get((string, string) key) 
    {
        return _itemGenerators[key]();
    }
}