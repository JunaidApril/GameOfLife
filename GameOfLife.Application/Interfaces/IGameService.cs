namespace GameOfLife.Application.Interfaces
{
    /// <summary>
    /// Interface defining operations for managing the Game of Life.
    /// </summary>
    public interface IGameService
    {
        /// <summary>
        /// Creates a new game with the specified number of rows and columns.
        /// </summary>
        /// <param name="rows">Number of rows in the game grid.</param>
        /// <param name="cols">Number of columns in the game grid.</param>
        /// <returns>True if the game is successfully created, otherwise false.</returns>
        bool CreateGame(int rows, int cols);

        /// <summary>
        /// Runs the game for the given number of generations.
        /// </summary>
        /// <param name="generations">The number of generations to simulate.</param>
        void RunGame(int generations);
    }
}
