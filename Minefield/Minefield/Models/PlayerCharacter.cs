namespace Minefield.Models;

public class PlayerCharacter
{
    public uint Lives { get; set; }
    public uint Moves { get; set; }
    public Coordinates Coordinates { get; set; }
    
    public void RemoveLife()
    {
        if (Lives <= 0)
        {
            throw new Exception("No lives left");
        }
        
        Lives--;
    }
    
    public void IncrementMoves()
    {
        Moves++;
    }
    
    public void MoveUp()
    {
        Coordinates.Y++;
    }
    
    public void MoveDown()
    {
        Coordinates.Y--;
    }
    
    public void MoveLeft()
    {
        Coordinates.X--;
    }
    
    public void MoveRight()
    {
        Coordinates.X++;
    }
}