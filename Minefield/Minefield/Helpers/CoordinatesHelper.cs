using Minefield.Models;

namespace Minefield.Helpers;

public static class CoordinatesHelper
{
    public static void EnforceBoundaries(this Coordinates coordinates, Coordinates maxCoordinates)
    {
        coordinates.X = (coordinates.X < 0) ? 0 : (coordinates.X > maxCoordinates.X) ? maxCoordinates.X : coordinates.X;
        coordinates.Y = (coordinates.Y < 0) ? 0 : (coordinates.Y > maxCoordinates.Y) ? maxCoordinates.Y : coordinates.Y;
    }
    
    public static bool IsEqual(this Coordinates coordinates, Coordinates otherCoordinates)
    {
        return coordinates.X == otherCoordinates.X && coordinates.Y == otherCoordinates.Y;
    }
}