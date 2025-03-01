using GameOfLife.Domain.Entities;

namespace GameOfLife.Tests
{
    [TestFixture]
    public class GameOfLifeTests
    {
        [Test]
        public void Board_Should_Initialize_With_Valid_Dimensions()
        {
            // Arrange
            int rows = 5, cols = 5;
            var game = new Game(rows, cols);

            // Act & Assert
            Assert.NotNull(game);
        }

        [Test]
        public void Board_Should_Contain_Only_Zeros_Or_Ones()
        {
            // Arrange
            int rows = 5, cols = 5;
            var game = new Game(rows, cols);

            // Act & Assert
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Assert.That(game.GetCellState(i, j), Is.EqualTo(0).Or.EqualTo(1));
                }
            }
        }

        [Test]
        public void Underpopulation_Should_Kill_Lonely_Cell()
        {
            // Arrange
            int[,] customBoard = {
                { 0, 0, 0 },
                { 0, 1, 0 },
                { 0, 0, 0 }
            };
            var game = new Game(3, 3, customBoard);

            // Act
            game.NextGeneration();

            // Assert: Cell should die
            Assert.AreEqual(0, game.GetCellState(1, 1));
        }

        [Test]
        public void Live_Cell_With_Two_Or_Three_Neighbors_Should_Survive()
        {
            // Arrange
            int[,] customBoard = {
                { 0, 1, 0 },
                { 1, 1, 0 },
                { 0, 0, 0 }
            };
            var game = new Game(3, 3, customBoard);

            // Act
            game.NextGeneration();

            // Assert: Middle cell should stay alive
            Assert.AreEqual(1, game.GetCellState(1, 1));
        }

        [Test]
        public void Overpopulation_Should_Kill_Cell()
        {
            // Arrange
            int[,] customBoard = {
                { 1, 1, 1 },
                { 1, 1, 0 },
                { 0, 0, 0 }
            };
            var game = new Game(3, 3, customBoard);

            // Act
            game.NextGeneration();

            // Assert: Center cell should die
            Assert.AreEqual(0, game.GetCellState(1, 1));
        }

        [Test]
        public void Dead_Cell_With_Exactly_Three_Live_Neighbors_Should_Become_Alive()
        {
            // Arrange
            int[,] customBoard = {
                { 0, 1, 0 },
                { 1, 0, 1 },
                { 0, 0, 0 }
            };
            var game = new Game(3, 3, customBoard);

            // Act
            game.NextGeneration();

            // Assert: Center cell should come to life
            Assert.AreEqual(1, game.GetCellState(1, 1));
        }

        [Test]
        public void Edge_Cells_Should_Be_Handled_Correctly()
        {
            // Arrange
            int[,] customBoard = {
                { 1, 1, 0 },
                { 1, 0, 0 },
                { 0, 0, 0 }
            };
            var game = new Game(3, 3, customBoard);

            // Act
            game.NextGeneration();

            // Assert: Top-left cell should survive
            Assert.AreEqual(1, game.GetCellState(0, 0));
        }
    }
}
