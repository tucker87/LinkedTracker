namespace LinkedTracker.Data.Models;

public class PointOfInterest : IIndexed
{
    public PointOfInterest(int x, int y)
    {
        X = x;
        Y = y;
    }
    public int Index { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsDone { get; set; }
}