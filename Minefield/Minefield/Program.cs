// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Minefield.Controllers;
using Minefield.Services;

public class Game
{
    public static void Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
            .AddLogging()
            .AddSingleton<IGameManagementService, GameManagementService>()
            .AddSingleton<IIoController, IoController>()
            .BuildServiceProvider();

        var gameManagementService = serviceProvider.GetService<IGameManagementService>();
        var ioController = serviceProvider.GetService<IIoController>();
        var logger = serviceProvider.GetService<ILogger>();
        
        try
        {
            ioController?.StartIo(gameManagementService?.StartGame() ?? throw new Exception("Game management service not found"));
        }
        catch (Exception e)
        {
            logger?.LogError($"{e}");
            Console.WriteLine(e.Message);
        }
    }
}