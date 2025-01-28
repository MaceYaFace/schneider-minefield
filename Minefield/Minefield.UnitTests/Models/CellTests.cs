using Minefield.Models;

namespace Minefield.UnitTests.Models;

public class CellTests
{
    [Test]
    public void Given_Cell_When_PlayerOnCellCalled_Then_CellIsCheckedAndIsPlayer()
    {
        var cell = new Cell();
        
        cell.PlayerOnCell();
        Assert.Multiple(() =>
        {
            Assert.That(cell.IsChecked, Is.True);
            Assert.That(cell.IsPlayer, Is.True);
        });
    }
}