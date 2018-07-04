using FluentAssertions;
using ThreadingExplore.Core.TicTacToe;
using Xunit;

namespace ThreadingExplore.UnitTests.TicTacToe
{
    public class TicTacToeGameForMakeNextMoveTests
    {
        [Theory]
        [InlineData("XX-", "XXO", TicTacToeGame.CellValue.O)]
        [InlineData("X-X", "XOX", TicTacToeGame.CellValue.O)]
        [InlineData("-XX", "OXX", TicTacToeGame.CellValue.O)]
        [InlineData("OO-", "OOX", TicTacToeGame.CellValue.X)]
        [InlineData("O-O", "OXO", TicTacToeGame.CellValue.X)]
        [InlineData("-OO", "XOO", TicTacToeGame.CellValue.X)]
        public void ShouldMakeTopRowBockForO(
            string inputRow,
            string expectedRow,
            TicTacToeGame.CellValue cellValue)
        {
            var grid = new string[]
            {
                inputRow,
                "---",
                "---",
            };

            var ticTacToeGame = new TicTacToeGame(grid);

            ticTacToeGame.MakeNextMoveFor(cellValue);

            var stringBoard = ticTacToeGame.GetStringBoard();

            stringBoard[0].Should().Be(expectedRow);
            stringBoard[1].Should().Be("---");
            stringBoard[2].Should().Be("---");
        }

        [Theory]
        [InlineData("XX-", "XXO", TicTacToeGame.CellValue.O)]
        [InlineData("X-X", "XOX", TicTacToeGame.CellValue.O)]
        [InlineData("-XX", "OXX", TicTacToeGame.CellValue.O)]
        [InlineData("OO-", "OOX", TicTacToeGame.CellValue.X)]
        [InlineData("O-O", "OXO", TicTacToeGame.CellValue.X)]
        [InlineData("-OO", "XOO", TicTacToeGame.CellValue.X)]
        public void ShouldMakeMiddleRowBockForO(
            string inputRow,
            string expectedRow,
            TicTacToeGame.CellValue cellValue)
        {
            var grid = new string[]
            {
                "---",
                inputRow,
                "---",
            };

            var ticTacToeGame = new TicTacToeGame(grid);

            ticTacToeGame.MakeNextMoveFor(cellValue);

            var stringBoard = ticTacToeGame.GetStringBoard();

            stringBoard[0].Should().Be("---");
            stringBoard[1].Should().Be(expectedRow);
            stringBoard[2].Should().Be("---");
        }

        [Theory]
        [InlineData("XX-", "XXO", TicTacToeGame.CellValue.O)]
        [InlineData("X-X", "XOX", TicTacToeGame.CellValue.O)]
        [InlineData("-XX", "OXX", TicTacToeGame.CellValue.O)]
        [InlineData("OO-", "OOX", TicTacToeGame.CellValue.X)]
        [InlineData("O-O", "OXO", TicTacToeGame.CellValue.X)]
        [InlineData("-OO", "XOO", TicTacToeGame.CellValue.X)]
        public void ShouldMakeBottomRowBockForO(
            string inputRow,
            string expectedRow,
            TicTacToeGame.CellValue cellValue)
        {
            var grid = new string[]
            {
                "---",
                "---",
                inputRow,
            };

            var ticTacToeGame = new TicTacToeGame(grid);

            ticTacToeGame.MakeNextMoveFor(cellValue);

            var stringBoard = ticTacToeGame.GetStringBoard();

            stringBoard[0].Should().Be("---");
            stringBoard[1].Should().Be("---");
            stringBoard[2].Should().Be(expectedRow);
        }

    }
}