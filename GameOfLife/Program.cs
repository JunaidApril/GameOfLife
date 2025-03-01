using Microsoft.Extensions.DependencyInjection;
using GameOfLife.Domain.Interfaces;
using GameOfLife.Domain.Entities;
using GameOfLife.Application.Interfaces;
using GameOfLife.Application.Services;
using Microsoft.Extensions.Logging;

// Create the GameService and start the game
RunApplication();

/// <summary>
/// Configures the dependency injection container and returns a service provider.
/// </summary>
static ServiceProvider ConfigureServices()
{
    var services = new ServiceCollection();

    // Add Logging Service
    services.AddLogging(configure =>
    {
        configure.AddConsole(); // Log to console
        configure.SetMinimumLevel(LogLevel.Information);
    });

    // Register services
    services.AddSingleton<IGame, Game>();
    services.AddSingleton<IGameService, GameService>();

    return services.BuildServiceProvider();
}

/// <summary>
/// Runs the Game of Life application.
/// </summary>
static void RunApplication()
{
    // Configure services and build the service provider
    var serviceProvider = ConfigureServices();

    Console.WriteLine("Welcome to Conway's Game of Life!");

    var game = serviceProvider.GetRequiredService<IGameService>();
    bool isGameCreated = false;
    int generations = 0;

    while (!isGameCreated)
    {
        // Get user input for board size and number of generations
        Console.Write("Enter number of rows: ");
        int rows = int.Parse(Console.ReadLine());

        Console.Write("Enter number of columns: ");
        int cols = int.Parse(Console.ReadLine());

        Console.Write("Enter number of generations: ");
        generations = int.Parse(Console.ReadLine());

        isGameCreated = game.CreateGame(rows, cols);
    }

    game.RunGame(generations);
}