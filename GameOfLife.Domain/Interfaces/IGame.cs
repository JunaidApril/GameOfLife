namespace GameOfLife.Domain.Interfaces
{
    public interface IGame
    {
        void InitializeBoard();
        void PrintBoard();
        void NextGeneration();
    }
}
