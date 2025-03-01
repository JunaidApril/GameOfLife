namespace GameOfLife.Application.Interfaces
{
    public interface IGameService
    {
        bool CreateGame(int rows, int cols);
        void RunGame(int generations);
    }
}
