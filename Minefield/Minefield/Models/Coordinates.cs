namespace Minefield.Models;

public class Coordinates(int x = 0, int y = 0)
{
    public int X { get; set; } = x;
    public int Y { get; set; } = y;
}