using Minefield.Models;

namespace Minefield.UnitTests.Models;

[TestFixture]
public class PlayerCharacterTests
{
    [Test]
    public void Given_PlayerCharacterWithLives_When_RemoveLifeCalled_Then_LivesDecreasedByOne()
    {
        var pc = new PlayerCharacter(new())
        {
            Lives = 3
        };

        pc.RemoveLife();

        Assert.That(pc.Lives, Is.EqualTo(2));
    }

    [Test]
    public void Given_PlayerCharacterRemoveLifeCalled_When_LivesAreZero_Then_CorrectExceptionThrown()
    {
        var pc = new PlayerCharacter(new())
        {
            Lives = 0
        };

        Assert.That(() => pc.RemoveLife(), Throws.Exception, "No lives left");
    }
    
    [Test]
    public void Given_PlayerCharacter_When_IncrementMovesCalled_Then_MovesIncreasedByOne()
    {
        var pc = new PlayerCharacter(new())
        {
            Moves = 0
        };

        pc.IncrementMoves();

        Assert.That(pc.Moves, Is.EqualTo(1));
    }
    
    [Test]
    public void Given_PlayerCharacter_When_MoveUpIsCalled_Then_CoordinatesYIncreasedByOne()
    {
        var pc = new PlayerCharacter(new());

        pc.MoveUp();

        Assert.That(pc.Coordinates.Y, Is.EqualTo(1));
    }
    
    [Test]
    public void Given_PlayerCharacter_When_MoveDownIsCalled_Then_CoordinatesYDecreasedByOne()
    {
        var pc = new PlayerCharacter(new());

        pc.MoveDown();

        Assert.That(pc.Coordinates.Y, Is.EqualTo(-1));
    }
    
    [Test]
    public void Given_PlayerCharacter_When_MoveLeftIsCalled_Then_CoordinatesXDecreasedByOne()
    {
        var pc = new PlayerCharacter(new());

        pc.MoveLeft();

        Assert.That(pc.Coordinates.X, Is.EqualTo(-1));
    }
    
    [Test]
    public void Given_PlayerCharacter_When_MoveRightIsCalled_Then_CoordinatesXIncreasedByOne()
    {
        var pc = new PlayerCharacter(new());

        pc.MoveRight();

        Assert.That(pc.Coordinates.X, Is.EqualTo(1));
    }
}