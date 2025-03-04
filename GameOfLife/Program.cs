using Microsoft.Extensions.DependencyInjection;
using GameOfLife.Domain.Interfaces;
using GameOfLife.Domain.Entities;
using GameOfLife.Application.Interfaces;
using GameOfLife.Application.Services;
using Microsoft.Extensions.Logging;
using GameOfLife.Domain.Errors;
using GameOfLife.Domain.UserMessages;

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
    int height = 0;
    int width = 0;

    try 
    {
        // Get user input for board size and number of generations

        //get width
        Console.WriteLine(string.Format(InputMessages.InitialUserRequest, "width"));


        while (!Int32.TryParse(Console.ReadLine(), out width) || width < 0)
        {
            Console.WriteLine(string.Format(InputMessages.AfterIncorrectAttemptUserRequest, "width"));
        }

        //get height
        Console.WriteLine(string.Format(InputMessages.InitialUserRequest, "height"));

        while (!Int32.TryParse(Console.ReadLine(), out height) || height < 0)
        {
            Console.WriteLine(string.Format(InputMessages.AfterIncorrectAttemptUserRequest, "height"));
        }

        //get max num generations
        Console.WriteLine(InputMessages.InitialGenerationRequest);

        while (!Int32.TryParse(Console.ReadLine(), out generations) || generations < 0)
        {
            Console.WriteLine(InputMessages.AfterIncorrectGenerationAttempt);
        }

        isGameCreated = game.CreateGame(height, width);

        if(!isGameCreated)
            Console.WriteLine(ErrorMessage.GeneralCreatingError);

        game.RunGame(generations);

    }
    catch (FormatException)
    {
        Console.WriteLine(ErrorMessage.InvalidInputType);
    }
}