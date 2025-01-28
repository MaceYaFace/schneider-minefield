namespace Minefield.Models;

public class Coordinates(int x, int y)
{
    public int X { get; set; } = x;
    public int Y { get; set; } = y;
}