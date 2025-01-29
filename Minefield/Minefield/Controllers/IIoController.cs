using Minefield.Models;

namespace Minefield.Controllers;

public interface IIoController
{
    public void StartIo(GameState gameState);
}