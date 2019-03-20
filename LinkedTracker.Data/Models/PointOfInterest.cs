public class PointOfInterest
{
    public PointOfInterest(int x, int y)
    {
        X = x;
        Y = y;
    }
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsDone { get; set; }
}