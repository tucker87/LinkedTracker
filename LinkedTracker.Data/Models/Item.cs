namespace LinkedTracker.Data.Models;

public record Item(ItemType Type, bool Collected = false)
{
    public string TypeName => Type.ToString();
}