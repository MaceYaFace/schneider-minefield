using Microsoft.Extensions.Logging;
using Minefield.Enums;
using Minefield.Services;
using Moq;

namespace Minefield.UnitTests.Services;

[TestFixture]
public class GameManagementServiceTests
{
    private GameManagementService _gameManagementService;

    [SetUp]
    public void SetUp()
    {
        _gameManagementService = new GameManagementService(new Mock<ILogger<IGameManagementService>>().Object);
        _gameManagementService.StartGame();
    }

    [Test]
    public void Given_ValidKeyPress_When_HandleInputCalled_Then_GameStateUpdated()
    {
        var keyInfo = new ConsoleKeyInfo('W', ConsoleKey.W, false, false, false);
        var updatedGameState = _gameManagementService.HandleInput(keyInfo);

        Assert.Multiple(() =>
        {
            Assert.That(updatedGameState.Moves, Is.GreaterThanOrEqualTo(0));
            Assert.That(updatedGameState.Moves, Is.LessThan(2));
            Assert.That(updatedGameState.Cells.Where(c => c.State == CellState.Player).ToList(), Has.Count.LessThan(2));
        });
    }

    [Test]
    public void Given_InvalidKeyPress_When_HandleInputCalled_Then_GameStateUnchanged()
    {
        var keyInfo = new ConsoleKeyInfo('X', ConsoleKey.X, false, false, false);
        var updatedGameState = _gameManagementService.HandleInput(keyInfo);

        Assert.Multiple(() =>
        {
            Assert.That(updatedGameState.Moves, Is.GreaterThanOrEqualTo(0));
            Assert.That(updatedGameState.Moves, Is.LessThan(2));
            Assert.That(updatedGameState.Cells.Where(c => c.State == CellState.Player).ToList(), Has.Count.LessThan(2));
        });
    }
}