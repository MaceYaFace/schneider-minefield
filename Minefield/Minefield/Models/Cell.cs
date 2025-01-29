using System.IO.IsolatedStorage;
using Minefield.Enums;

namespace Minefield.Models;

public class Cell
{
    public Coordinates Coordinates { get; set; }
    public CellState State { get; set; }
}