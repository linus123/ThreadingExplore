using FluentAssertions;
using ThreadingExplore.Core.TicTacToe;
using Xunit;

namespace ThreadingExplore.UnitTests.TicTacToe
{
    public class TicTacToeGameForMakeNextMoveTests
    {
        [Theory]
        [InlineData("XX-", "XXO")]
        [InlineData("X-X", "XOX")]
        [InlineData("-XX", "OXX")]
        public void ShouldMakeTopRowBockForO(
            string inputRow,
            string expectedRow)
        {
            var grid = new string[]
            {
                inputRow,
                "---",
                "---",
            };

            var ticTacToeGame = new TicTacToeGame(grid);

            ticTacToeGame.MakeNextMoveForO();

            var stringBoard = ticTacToeGame.GetStringBoard();

            stringBoard[0].Should().Be(expectedRow);
            stringBoard[1].Should().Be("---");
            stringBoard[2].Should().Be("---");
        }

        [Theory]
        [InlineData("XX-", "XXO")]
        [InlineData("X-X", "XOX")]
        [InlineData("-XX", "OXX")]
        public void ShouldMakeMiddleRowBockForO(
            string inputRow,
            string expectedRow)
        {
            var grid = new string[]
            {
                "---",
                inputRow,
                "---",
            };

            var ticTacToeGame = new TicTacToeGame(grid);

            ticTacToeGame.MakeNextMoveForO();

            var stringBoard = ticTacToeGame.GetStringBoard();

            stringBoard[0].Should().Be("---");
            stringBoard[1].Should().Be(expectedRow);
            stringBoard[2].Should().Be("---");
        }

        [Theory]
        [InlineData("XX-", "XXO")]
        [InlineData("X-X", "XOX")]
        [InlineData("-XX", "OXX")]
        public void ShouldMakeBottomRowBockForO(
            string inputRow,
            string expectedRow)
        {
            var grid = new string[]
            {
                "---",
                "---",
                inputRow,
            };

            var ticTacToeGame = new TicTacToeGame(grid);

            ticTacToeGame.MakeNextMoveForO();

            var stringBoard = ticTacToeGame.GetStringBoard();

            stringBoard[0].Should().Be("---");
            stringBoard[1].Should().Be("---");
            stringBoard[2].Should().Be(expectedRow);
        }

    }
}