using FluentAssertions;
using ThreadingExplore.Core.TicTacToe;
using Xunit;

namespace ThreadingExplore.UnitTests.TicTacToe
{
    public class TicTacToeGameForWinDetectionTests
    {
        [Fact]
        public void IsWonShouldBeFalseForBlankGrid()
        {
            var board = new TicTacToeBoard();

            var winStatus = WinDetector.GetWinStatus(board);

            winStatus.IsWon.Should().BeFalse();
        }

        [Fact]
        public void IsWonShouldBeFalseForNoWinningMoves()
        {
            var grid = new string[]
            {
                "X--",
                "-O-",
                "O-X",
            };

            var board = new TicTacToeBoard(grid);

            var winStatus = WinDetector.GetWinStatus(board);

            winStatus.IsWon.Should().BeFalse();
        }

        [Theory]
        [InlineData(0, TicTacToeCellValue.X)]
        [InlineData(1, TicTacToeCellValue.X)]
        [InlineData(2, TicTacToeCellValue.X)]
        [InlineData(0, TicTacToeCellValue.O)]
        [InlineData(1, TicTacToeCellValue.O)]
        [InlineData(2, TicTacToeCellValue.O)]
        public void IsWonShouldBeTrueForHorizonalWin(
            int y,
            TicTacToeCellValue cellValue)
        {
            var board = new TicTacToeBoard();

            board.SetCellValue(0, y, cellValue);
            board.SetCellValue(1, y, cellValue);
            board.SetCellValue(2, y, cellValue);

            var winStatus = WinDetector.GetWinStatus(board);

            winStatus.IsWon.Should().BeTrue();
            winStatus.WinMessage.Should().Be($"Row win for {cellValue} on row {y + 1}");
        }

        [Theory]
        [InlineData(0, TicTacToeCellValue.X)]
        [InlineData(1, TicTacToeCellValue.X)]
        [InlineData(2, TicTacToeCellValue.X)]
        [InlineData(0, TicTacToeCellValue.O)]
        [InlineData(1, TicTacToeCellValue.O)]
        [InlineData(2, TicTacToeCellValue.O)]
        public void IsWonShouldBeTrueForVerticalWin(
            int x,
            TicTacToeCellValue cellValue)
        {
            var board = new TicTacToeBoard();

            board.SetCellValue(x, 0, cellValue);
            board.SetCellValue(x, 1, cellValue);
            board.SetCellValue(x, 2, cellValue);

            var winStatus = WinDetector.GetWinStatus(board);

            winStatus.IsWon.Should().BeTrue();
            winStatus.WinMessage.Should().Be($"Column win for {cellValue} on column {x + 1}");
        }
    }
}