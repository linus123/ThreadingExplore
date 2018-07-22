using FluentAssertions;
using ThreadingExplore.Core.TicTacToe;
using Xunit;

namespace ThreadingExplore.UnitTests.TicTacToe
{
    public class TieDetectorTests
    {
        [Fact]
        public void ShouldReturnFalseOnBlankBoard()
        {
            var board = new TicTacToeBoard();

            var isTied = TieDetector.IsTied(board);

            isTied.Should().BeFalse();
        }

        [Fact]
        public void ShouldReturnFalseSinglePopulatedCell()
        {
            var board = new TicTacToeBoard();

            board.SetCellValue(0, 0, TicTacToeCellValue.O);

            var isTied = TieDetector.IsTied(board);

            isTied.Should().BeFalse();
        }

        [Fact]
        public void ShouldReturnTrueWhenAllCellsAreNotBlank()
        {
            var grid = new string[]
            {
                "XXX",
                "OOO",
                "XXX",
            };

            var board = new TicTacToeBoard(grid);

            var isTied = TieDetector.IsTied(board);

            isTied.Should().BeTrue();
        }
    }
}