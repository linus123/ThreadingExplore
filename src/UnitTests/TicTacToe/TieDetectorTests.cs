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
    }
}