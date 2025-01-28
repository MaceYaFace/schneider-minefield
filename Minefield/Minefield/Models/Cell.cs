namespace Minefield.Models;

public class Cell
{
    public Coordinates Coordinates { get; set; }
    public bool IsMine { get; set; }
    public bool IsChecked { get; set; } = false;
    public bool IsPlayer { get; set; } = false;

    public void PlayerOnCell()
    {
        IsChecked = true;
        IsPlayer = true;
    }
}