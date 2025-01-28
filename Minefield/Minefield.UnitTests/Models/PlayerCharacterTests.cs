using Minefield.Models;

namespace Minefield.UnitTests.Models;

[TestFixture]
public class PlayerCharacterTests
{
    [Test]
    public void Given_PlayerCharacterWithLives_When_RemoveLifeCalled_Then_LivesDecreasedByOne()
    {
        var pc = new PlayerCharacter
        {
            Lives = 3
        };

        pc.RemoveLife();

        Assert.That(pc.Lives, Is.EqualTo(2));
    }

    [Test]
    public void Given_PlayerCharacterRemoveLifeCalled_When_LivesAreZero_Then_CorrectExceptionThrown()
    {
        var pc = new PlayerCharacter
        {
            Lives = 0
        };

        Assert.That(() => pc.RemoveLife(), Throws.Exception, "No lives left");
    }
    
    [Test]
    public void Given_PlayerCharacter_When_IncrementMovesCalled_Then_MovesIncreasedByOne()
    {
        var pc = new PlayerCharacter
        {
            Moves = 0
        };

        pc.IncrementMoves();

        Assert.That(pc.Moves, Is.EqualTo(1));
    }
}