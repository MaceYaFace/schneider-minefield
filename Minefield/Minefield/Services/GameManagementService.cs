using Microsoft.Extensions.Logging;
using Minefield.Enums;
using Minefield.Helpers;
using Minefield.Models;

namespace Minefield.Services;

public class GameManagementService(ILogger<IGameManagementService> logger) : IGameManagementService
{
    private GameState _gameState = new();
    private Models.Minefield _minefield = new();
    private PlayerCharacter _playerCharacter = new(new Coordinates());
    
    public bool Exited { get; private set; }
    
    public GameState StartGame(uint? wins = null, uint? lives = null, uint? moves = null)
    {
        var rnd = new Random();
        _minefield.GenerateCells();
        
        var startCell = _minefield.Cells
            .Where(c => c.Coordinates.Y == 0)
            .OrderBy(_ => rnd.Next()).FirstOrDefault(c => c.State != CellState.UncheckedMine);
        if (startCell == null)
        {
            startCell = _minefield.Cells.OrderBy(_ => rnd.Next()).FirstOrDefault();
            if (startCell == null)
            {
                throw new Exception("Minefield has no cells");
            }
            _minefield.Cells.Select(c => c).First(c => c == startCell).State = CellState.Player;
            _minefield.MineCount--;

            if (_minefield.MineCount == 0)
            {
                _minefield.Cells.OrderBy(_ => rnd.Next()).First(c => c != startCell).State = CellState.UncheckedMine;
            }

            if (_minefield.MineCount == _minefield.Cells.Count - 2)
            {
                var x = rnd.Next(Math.Min(startCell.Coordinates.X - 1, 0), Math.Max(startCell.Coordinates.X + 1, 0));
                var y = rnd.Next(Math.Min(startCell.Coordinates.Y - 1, 0), Math.Max(startCell.Coordinates.Y + 1, 0));
                
                _minefield.Cells.Select(c => c).First(c => c.Coordinates.X == x && c.Coordinates.Y == y).State = CellState.UncheckedMine;
            }
            
        }
        _playerCharacter.Coordinates = new Coordinates(startCell.Coordinates.X, startCell.Coordinates.Y);
        _minefield.Cells = _minefield.Cells
            .Select(c =>
            {
                if (c.Coordinates.IsEqual(_playerCharacter.Coordinates))
                {
                    c.State = CellState.Player;
                }
                return c;
            }).ToList();
        _playerCharacter.Lives = lives ?? _playerCharacter.Lives;
        _playerCharacter.Moves = moves ?? _playerCharacter.Moves;
        
        _gameState.Wins = wins ?? _gameState.Wins;
        _gameState.Cells = _minefield.Cells;
        _gameState.MaxCoordinates = _minefield.MaxCoordinates;
        _gameState.Lives = _playerCharacter.Lives;
        _gameState.Moves = _playerCharacter.Moves;

        return _gameState;
    }

    public GameState HandleInput(ConsoleKeyInfo key)
    {
        var currentCoordinates = new Coordinates(_playerCharacter.Coordinates.X, _playerCharacter.Coordinates.Y);
        switch (key.Key)
        {
            case ConsoleKey.W:
            case ConsoleKey.UpArrow:
                _playerCharacter.MoveUp();
                _playerCharacter.Coordinates.EnforceBoundaries(_minefield.MaxCoordinates);
                if (!currentCoordinates.IsEqual(_playerCharacter.Coordinates))
                {
                    _playerCharacter.Moves++;
                }
                return UpdateGameState();
            case ConsoleKey.S:
            case ConsoleKey.DownArrow:
                _playerCharacter.MoveDown();
                _playerCharacter.Coordinates.EnforceBoundaries(_minefield.MaxCoordinates);
                if (!currentCoordinates.IsEqual(_playerCharacter.Coordinates))
                {
                    _playerCharacter.Moves++;
                }
                return UpdateGameState();
            case ConsoleKey.A:
            case ConsoleKey.LeftArrow:
                _playerCharacter.MoveLeft();
                _playerCharacter.Coordinates.EnforceBoundaries(_minefield.MaxCoordinates);
                if (!currentCoordinates.IsEqual(_playerCharacter.Coordinates))
                {
                    _playerCharacter.Moves++;
                }
                return UpdateGameState();
            case ConsoleKey.D:
            case ConsoleKey.RightArrow:
                _playerCharacter.MoveRight();
                _playerCharacter.Coordinates.EnforceBoundaries(_minefield.MaxCoordinates);
                if (!currentCoordinates.IsEqual(_playerCharacter.Coordinates))
                {
                    _playerCharacter.Moves++;
                }
                return UpdateGameState();
            case ConsoleKey.Q:
                Environment.Exit(0);
                // Fallback exit in case Environment.Exit(0) fails
                Exited = true;
                return _gameState;
            default:
                return _gameState;
        }
    }
    
    private GameState UpdateGameState()
    {
        _minefield.Cells = _minefield.Cells
            .Select(c =>
            {
                switch (c.State)
                {
                    case CellState.Player:
                        c.State = CellState.CheckedSpace;
                        break;
                    case CellState.PlayerOnDetonatedMine:
                    case CellState.PlayerOnMine:
                        c.State = CellState.DetonatedMine;
                        break;
                }

                return c;
            }).ToList();
        
        try
        {
            _minefield.Cells = _minefield.Cells
                .Select(c =>
                {
                    if (c.Coordinates.IsEqual(_playerCharacter.Coordinates))
                    {
                        switch (c.State)
                        {
                            case CellState.UncheckedMine:
                                c.State = CellState.PlayerOnMine;
                                _playerCharacter.RemoveLife();
                                _minefield.MineCount--;
                                break;
                            case CellState.UncheckedSpace:
                            case CellState.CheckedSpace:
                                c.State = CellState.Player;
                                break;
                            case CellState.DetonatedMine:
                                c.State = CellState.PlayerOnDetonatedMine;
                                break;
                        }
                    }

                    return c;
                }).ToList();
        }
        catch (OutOfMemoryException e)
        {
            logger.LogWarning($"{e}");
            ResetGame();
            return StartGame();
        }

        if (_playerCharacter.Lives == 0)
        {
            ResetGame();
            return StartGame();
        }
        if (_minefield.MineCount == 0 || _minefield.Cells.Count(c => c.State == CellState.CheckedSpace) == _minefield.Cells.Count - _minefield.MineCount || _playerCharacter.Coordinates.Y == _minefield.MaxCoordinates.Y)
        {
            var wins = _gameState.Wins + 1;
            var lives = _playerCharacter.Lives;
            var moves = _playerCharacter.Moves;
            ResetGame();
            return StartGame(wins, lives, moves);
        }
        
        _gameState.Lives = _playerCharacter.Lives;
        _gameState.Moves = _playerCharacter.Moves;
        
        return _gameState;
    }
    
    private void ResetGame()
    {
        _minefield = new();
        _playerCharacter = new(new Coordinates());
        _gameState = new();
    }
}