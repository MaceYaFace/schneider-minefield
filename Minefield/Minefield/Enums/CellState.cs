namespace Minefield.Enums;

public enum CellState
{
    UncheckedMine,
    UncheckedSpace,
    DetonatedMine,
    CheckedSpace,
    PlayerOnMine,
    PlayerOnDetonatedMine,
    Player
}