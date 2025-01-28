namespace Minefield.UnitTests.Models;

[TestFixture]
public class MinefieldTests
{
    [Test]
    public void Given_Minefield_When_GenerateCellsCalled_Then_CellsGeneratedWithMines()
    {
        var minefield = new Minefield.Models.Minefield();
        
        minefield.GenerateCells();
        
        Assert.That(minefield.Cells.Count(c => c.IsMine), Is.EqualTo(25));
    }
}