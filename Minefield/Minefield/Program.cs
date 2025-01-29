// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;
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
        ioController.StartIo(gameManagementService.StartGame());
    }
}