namespace Minefield.Models;

public class PlayerCharacter
{
    public uint Lives { get; set; }
    
    public void RemoveLife()
    {
        if (Lives <= 0)
        {
            throw new Exception("No lives left");
        }
        
        Lives--;
    }
}