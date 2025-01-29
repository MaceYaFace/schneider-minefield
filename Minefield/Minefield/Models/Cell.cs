using Minefield.Enums;

namespace Minefield.Models;

public class Cell
{
    public Coordinates Coordinates { get; init; } = new();
    public CellState State { get; set; }
}