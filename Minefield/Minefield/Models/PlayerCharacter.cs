using Minefield.Exceptions;

namespace Minefield.Models;

public class PlayerCharacter(Coordinates startPosition, uint lives = 3, uint moves = 0)
{
    public uint Lives { get; set; } = lives;
    public uint Moves { get; set; } = moves;
    public Coordinates Coordinates { get; set; } = startPosition;

    public void RemoveLife()
    {
        if (Lives <= 0)
        {
            throw new OutOfLivesException();
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