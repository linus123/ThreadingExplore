using FluentAssertions;
using ThreadingExplore.Core.TicTacToe;
using Xunit;

namespace ThreadingExplore.UnitTests.TicTacToe
{
    public class TicTacToeGameTests
    {
        [Fact]
        public void ConstructorShouldInitBlankGrid()
        {
            var game = new TicTacToeGame();

            AssertAllCellsAreBlank(game);
        }

        private static void AssertAllCellsAreBlank(TicTacToeGame game)
        {
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    game.GetCellValue(x, y).Should().Be(TicTacToeGame.CellValue.Blank);
                }
            }
        }

        [Fact]
        public void ConsructorShouldInitWillAllBlankCells()
        {
            var grid = new string[,]
            {
                { "---" },
                { "---" },
                { "---" },
            };

            var game = new TicTacToeGame(grid);

            AssertAllCellsAreBlank(game);
        }
    }
}