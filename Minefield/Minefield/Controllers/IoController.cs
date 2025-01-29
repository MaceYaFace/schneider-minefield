using Minefield.Enums;
using Minefield.Models;
using Minefield.Services;

namespace Minefield.Controllers;

public class IoController(IGameManagementService gameManagementService) : IIoController
{
    public void StartIo(GameState gameState)
    {
        DrawMinefield(gameState);
        while (gameManagementService.Exited == false)
        {
            DrawMinefield(AwaitUserInput());
        }
    }
    
    private void DrawMinefield(GameState gameState)
    {
        Console.Clear();
        Console.WriteLine("Welcome to Minefield!");
        Console.WriteLine();
        Console.WriteLine("Use the arrow keys/WASD to move the player character.");
        Console.WriteLine("Press 'Q' to quit the game.");
        for (var cols = gameState.MaxCoordinates.Y; cols > -1; cols--)
        {
            Console.WriteLine();
            for (var rows = 0; rows <= gameState.MaxCoordinates.X; rows++)
            {
                switch (gameState.Cells.FirstOrDefault(c => c.Coordinates.X == rows && c.Coordinates.Y == cols).State)
                {
                    case CellState.UncheckedMine:
                    case CellState.UncheckedSpace:
                        Console.Write("^ ");
                        break;
                    case CellState.CheckedSpace:
                        Console.Write("O ");
                        break;
                    case CellState.DetonatedMine:
                        Console.Write("* ");
                        break;
                    case CellState.PlayerOnMine:
                        Console.Write("X ");
                        break;
                    case CellState.Player:
                    case CellState.PlayerOnDetonatedMine:
                        Console.Write("P ");
                        break;
                }
            }
        }
        
        Console.WriteLine();
        Console.WriteLine($"Lives: {gameState.Lives} | Moves: {gameState.Moves} | Wins: {gameState.Wins}");
    }
    
    private GameState AwaitUserInput()
    {
        var key = Console.ReadKey();
        return gameManagementService.HandleInput(key);
    }
}