using Minefield.Enums;

namespace Minefield.Models;

public class Minefield
{
    public List<Cell> Cells { get; set; } = new();
    public Coordinates MaxCoordinates { get; set; } = new();
    public uint MineCount { get; set; }

    public void GenerateCells(float proportionMines = 0.25f, int maxWidth = 3, int maxHeight = 3)
    {
        var rnd = new Random();

        MaxCoordinates = new Coordinates(maxWidth - 1 , maxHeight - 1);
        
        MineCount = (uint)Math.Floor(maxWidth * maxHeight * proportionMines);
        
        for (var x = 0; x < maxWidth; x++)
        {
            for (var y = 0; y < maxHeight; y++)
            {
                Cells.Add(new Cell
                {
                    Coordinates = new Coordinates(x, y),
                    State = CellState.UncheckedSpace
                });
            }
            
        }
        
        Cells.OrderBy(c => rnd.Next()).Take((int)MineCount).ToList().ForEach(c => c.State = CellState.UncheckedMine);
    }
}
