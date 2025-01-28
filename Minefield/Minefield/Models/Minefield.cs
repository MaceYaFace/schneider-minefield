namespace Minefield.Models;

public class Minefield
{
    public Cell[] Cells { get; set; }
    public int MaxWidth { get; set; }
    public int MaxHeight { get; set; }
    public int MineCount { get; set; }

    public void GenerateCells(float proportionMines = 0.25f, int maxWidth = 10, int maxHeight = 10)
    {
        var rnd = new Random();
        
        MaxWidth = maxWidth;
        MaxHeight = maxHeight;
        
        var cellCount = MaxWidth * MaxHeight;
        MineCount = (int)Math.Floor(cellCount * proportionMines);
        
        Cells = new Cell[cellCount];
        for (var i = 0; i < cellCount; i++)
        {
            Cells[i] = new Cell
            {
                Coordinates = new Coordinates(i % MaxWidth, i / MaxWidth)
            };
        }
        
        Cells.OrderBy(c => rnd.Next()).Take(MineCount).ToList().ForEach(c => c.IsMine = true);
    }
}
