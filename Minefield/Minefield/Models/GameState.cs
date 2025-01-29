namespace Minefield.Models;

public class GameState
{
    public List<Cell> Cells { get; set; }
    public Coordinates MaxCoordinates { get; set; }
    public uint Lives { get; set; }
    public uint Moves { get; set; }
    public uint Wins { get; set; }
}