﻿using GameOfLife.Domain.Interfaces;

namespace GameOfLife.Domain.Entities
{
    /// <summary>
    /// Represents the Game of Life grid and its behavior.
    /// </summary>
    public class Game : IGame
    {
        private int[,] _board;
        private int _rows;
        private int _cols;

        /// <summary>
        /// Initializes a new instance of the Game class with the specified dimensions.
        /// </summary>
        /// <param name="rows">Number of rows in the game grid.</param>
        /// <param name="cols">Number of columns in the game grid.</param>
        /// <param name="initialState">Optional initial state of the board.</param>
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

        /// <summary>
        /// Gets the state of a cell at the specified position.
        /// </summary>
        /// <param name="row">Row index of the cell.</param>
        /// <param name="col">Column index of the cell.</param>
        /// <returns>The state of the cell (0 or 1).</returns>
        public int GetCellState(int row, int col) => _board[row, col];

        /// <summary>
        /// Initializes the board with random values (0 or 1).
        /// </summary>
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

        /// <summary>
        /// Prints the current state of the game board to the console.
        /// </summary>
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

        /// <summary>
        /// Computes the next generation of the game board based on the Game of Life rules.
        /// </summary>
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

        /// <summary>
        /// Counts the number of live neighbors surrounding a given cell.
        /// </summary>
        /// <param name="x">Row index of the cell.</param>
        /// <param name="y">Column index of the cell.</param>
        /// <returns>The number of live neighbors.</returns>
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
