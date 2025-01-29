using Minefield.Models;

namespace Minefield.Services;

public interface IGameManagementService
{
    public bool Exited { get; }
    
    public GameState StartGame(uint? wins = null, uint? lives = null, uint? moves = null);
    public GameState HandleInput(ConsoleKeyInfo key);
}