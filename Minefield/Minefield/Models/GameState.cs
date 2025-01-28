namespace Minefield.Models;

public class GameState
{
    public Cell[] Cells { get; set; }
    public uint Lives { get; set; }
    public uint Moves { get; set; }
    public bool PlayerOnMine { get; set; }
}