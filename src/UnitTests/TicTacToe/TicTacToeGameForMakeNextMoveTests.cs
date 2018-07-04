using FluentAssertions;
using ThreadingExplore.Core.TicTacToe;
using Xunit;

namespace ThreadingExplore.UnitTests.TicTacToe
{
    public class TicTacToeGameForMakeNextMoveTests
    {
        [Fact]
        public void ShouldMakeTopRowBockForO()
        {
            var grid = new string[]
            {
                "XX-",
                "---",
                "---",
            };

            var ticTacToeGame = new TicTacToeGame(grid);

            ticTacToeGame.MakeNextMoveForO();

            var stringBoard = ticTacToeGame.GetStringBoard();

            stringBoard[0].Should().Be("XXO");
            stringBoard[1].Should().Be("---");
            stringBoard[2].Should().Be("---");
        }
    }
}