namespace Minefield.Models;

public class GameState
{
    public List<Cell> Cells { get; set; } = new();
    public Coordinates MaxCoordinates { get; set; } = new();
    public uint Lives { get; set; }
    public uint Moves { get; set; }
    public uint Wins { get; set; }
}