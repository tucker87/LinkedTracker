using System;
using System.Collections.Generic;

public record Item(ItemType Type);

public enum ItemType
{
    Armor1,
    Armor2,
    Armor3,
    Hookshot,
    Boomerang1,
    Boomerang2,
    Pendant1,
    Pendant2,
    Pendant3,
}

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