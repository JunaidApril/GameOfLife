namespace GameOfLife.Domain.Interfaces
{
    /// <summary>
    /// Interface defining the basic operations for the Game of Life.
    /// </summary>
    public interface IGame
    {
        /// <summary>
        /// Initializes the game board with random values.
        /// </summary>
        void InitializeBoard();

        /// <summary>
        /// Prints the current state of the game board to the console.
        /// </summary>
        void PrintBoard();

        /// <summary>
        /// Advances the game to the next generation based on defined rules.
        /// </summary>
        void NextGeneration();
    }
}
