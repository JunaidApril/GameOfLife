using GameOfLife.Domain.Interfaces;

namespace GameOfLife.Domain.Entities
{
    public class Game : IGame
    {
        private int[,] _board;
        private int _rows;
        private int _cols;

        public Game(int rows, int cols, int[,] initialState = null)
        {
            _rows = rows;
            _cols = cols;
            _board = initialState ?? new int[rows, cols];
            if (initialState == null)
            {
                InitializeBoard();
            }
        }

        public int GetCellState(int row, int col) => _board[row, col];

        public void InitializeBoard()
        {
            var random = new Random();
            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _cols; j++)
                {
                    _board[i, j] = random.Next(0, 2);
                }
            }
        }

        public void PrintBoard()
        {
            Console.Clear();
            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _cols; j++)
                {
                    Console.Write(_board[i, j] == 1 ? "#" : ".");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public void NextGeneration()
        {
            int[,] newBoard = new int[_rows, _cols];

            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _cols; j++)
                {
                    int liveNeighbors = CountLiveNeighbors(i, j);
                    newBoard[i, j] = (_board[i, j] == 1 && (liveNeighbors == 2 || liveNeighbors == 3)) ||
                                     (_board[i, j] == 0 && liveNeighbors == 3) ? 1 : 0;
                }
            }

            _board = newBoard;
        }

        private int CountLiveNeighbors(int x, int y)
        {
            int liveNeighbors = 0;
            int[] directions = { -1, 0, 1 };

            foreach (var dx in directions)
            {
                foreach (var dy in directions)
                {
                    if (dx == 0 && dy == 0)
                        continue;

                    int nx = x + dx, ny = y + dy;

                    if (nx >= 0 && nx < _rows && ny >= 0 && ny < _cols)
                    {
                        liveNeighbors += _board[nx, ny];
                    }
                }
            }

            return liveNeighbors;
        }
    }
}
