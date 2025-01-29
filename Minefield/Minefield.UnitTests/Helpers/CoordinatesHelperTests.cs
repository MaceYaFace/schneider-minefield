using Minefield.Helpers;
using Minefield.Models;

namespace Minefield.UnitTests.Helpers;

[TestFixture]
    public class CoordinatesHelperTests
    {
        [Test]
        public void Given_CoordinatesExceedingBoundaries_When_EnforceBoundariesCalled_Then_CoordinatesAreAdjusted()
        {
            var coordinates = new Coordinates(10, 10);
            var maxCoordinates = new Coordinates(5, 5);

            coordinates.EnforceBoundaries(maxCoordinates);

        Assert.Multiple(() =>
        {
            Assert.That(coordinates.X, Is.EqualTo(5));
            Assert.That(coordinates.Y, Is.EqualTo(5));
        });
    }

        [Test]
        public void Given_CoordinatesBelowZero_When_EnforceBoundariesCalled_Then_CoordinatesAreAdjusted()
        {
            var coordinates = new Coordinates(-1, -1);
            var maxCoordinates = new Coordinates(5, 5);

            coordinates.EnforceBoundaries(maxCoordinates);

        Assert.Multiple(() =>
        {
            Assert.That(coordinates.X, Is.EqualTo(0));
            Assert.That(coordinates.Y, Is.EqualTo(0));
        });
    }

        [Test]
        public void Given_CoordinatesWithinBoundaries_When_EnforceBoundariesCalled_Then_CoordinatesRemainUnchanged()
        {
            var coordinates = new Coordinates(3, 3);
            var maxCoordinates = new Coordinates(5, 5);

            coordinates.EnforceBoundaries(maxCoordinates);

        Assert.Multiple(() =>
        {
            Assert.That(coordinates.X, Is.EqualTo(3));
            Assert.That(coordinates.Y, Is.EqualTo(3));
        });
    }

        [Test]
        public void Given_EqualCoordinates_When_IsEqualCalled_Then_ReturnsTrue()
        {
            var coordinates1 = new Coordinates(3, 3);
            var coordinates2 = new Coordinates(3, 3);

            var result = coordinates1.IsEqual(coordinates2);

            Assert.That(result, Is.True);
        }

        [Test]
        public void Given_DifferentCoordinates_When_IsEqualCalled_Then_ReturnsFalse()
        {
            var coordinates1 = new Coordinates(3, 3);
            var coordinates2 = new Coordinates(4, 4);

            var result = coordinates1.IsEqual(coordinates2);

            Assert.That(result, Is.False);
        }
    }