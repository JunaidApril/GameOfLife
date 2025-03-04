using GameOfLife.Application.Interfaces;
using GameOfLife.Domain.Entities;
using GameOfLife.Domain.Errors;
using GameOfLife.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace GameOfLife.Application.Services
{
    public class GameService : IGameService
    {
        private IGame _game;
        private readonly ILogger<GameService> _logger;

        public GameService(ILogger<GameService> logger) 
        {
            _logger = logger;
        }

        /// <summary>
        /// Creates a new game instance with the specified number of rows and columns.
        /// </summary>
        /// <param name="rows">Number of rows for the game grid.</param>
        /// <param name="cols">Number of columns for the game grid.</param>
        /// <returns>True if the game is successfully created, otherwise false.</returns>
        public bool CreateGame(int rows, int cols)
        {
            try
            {
                if (rows < 0 || cols < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                _game = new Game(rows, cols);
                _logger.LogInformation($"Game created with size {rows}x{cols}.");

                return true;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                _logger.LogWarning(ex, ErrorMessage.InvalidDimensions);
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorMessage.GeneralCreatingError);
                return false;
            }
        }

        /// <summary>
        /// Runs the game for the specified number of generations.
        /// </summary>
        /// <param name="generations">The number of generations to run the simulation.</param>
        public void RunGame(int generations)
        {
            try
            {
                if (_game == null)
                {
                    throw new ArgumentException();
                }

                for (int i = 0; i < generations; i++)
                {
                    Console.WriteLine($"Generation {i + 1}");
                    _game.PrintBoard();
                    _game.NextGeneration();
                    Thread.Sleep(1000); // Delay between generations
                }
            }
            catch(ArgumentException ex)
            {
                _logger.LogError(ex.Message, ErrorMessage.GameNotCreated);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorMessage.GeneralRunningError);
            }
        }
    }
}
