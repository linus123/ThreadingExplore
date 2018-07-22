using System.Collections;
using System.Collections.Generic;
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
            var board = new TicTacToeBoard();

            AssertAllCellsAreBlank(board);
        }

        [Theory]
        [ClassData(typeof(EachCellWithXandO))]
        public void SetCellValueShouldChangeCellValues(
            int x,
            int y,
            TicTacToeCellValue cellValue)
        {
            var board = new TicTacToeBoard();

            board.SetCellValue(x, y, cellValue);
            board.GetCellValue(x, y).Should().Be(cellValue);

            board.SetCellValue(x, y, TicTacToeCellValue.Blank);
            board.GetCellValue(x, y).Should().Be(TicTacToeCellValue.Blank);

            AssertAllCellsAreBlank(board);
        }

        [Fact]
        public void ConsructorShouldInitWillAllBlankCells()
        {
            var grid = new string[]
            {
                "---",
                "---",
                "---",
            };

            var board = new TicTacToeBoard(grid);

            AssertAllCellsAreBlank(board);
        }

        [Fact]
        public void ConsructorShouldInitRandomGames()
        {
            var grid = new string[]
            {
                "X--",
                "-O-",
                "O-X",
            };

            var board = new TicTacToeBoard(grid);

            board.GetCellValue(0, 0).Should().Be(TicTacToeCellValue.X);
            board.GetCellValue(1, 0).Should().Be(TicTacToeCellValue.Blank);
            board.GetCellValue(1, 1).Should().Be(TicTacToeCellValue.O);
            board.GetCellValue(0, 2).Should().Be(TicTacToeCellValue.O);
            board.GetCellValue(1, 2).Should().Be(TicTacToeCellValue.Blank);
            board.GetCellValue(2, 2).Should().Be(TicTacToeCellValue.X);
        }

        [Fact]
        public void GetStringBoardShouldReturnLayoutOfBoardWithAllBlanks()
        {
            var board = new TicTacToeBoard();

            var stringBoard = board.GetStringBoard();

            stringBoard[0].Should().Be("---");
            stringBoard[1].Should().Be("---");
            stringBoard[2].Should().Be("---");
        }

        [Fact]
        public void GetStringBoardShouldReturnLayoutOfBoardWithMixOfXAndOs()
        {
            var board = new TicTacToeBoard();

            board.SetCellValue(0, 0, TicTacToeCellValue.X);
            board.SetCellValue(1, 0, TicTacToeCellValue.O);
            board.SetCellValue(1, 1, TicTacToeCellValue.O);
            board.SetCellValue(1, 2, TicTacToeCellValue.X);

            var stringBoard = board.GetStringBoard();

            stringBoard[0].Should().Be("XO-");
            stringBoard[1].Should().Be("-O-");
            stringBoard[2].Should().Be("-X-");
        }


        private static void AssertAllCellsAreBlank(TicTacToeBoard board)
        {
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    board.GetCellValue(x, y).Should().Be(TicTacToeCellValue.Blank);
                }
            }
        }

        public class EachCellWithXandO : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                for (int x = 0; x < 3; x++)
                {
                    for (int y = 0; y < 3; y++)
                    {
                        yield return new object[] { x, y, TicTacToeCellValue.X };
                        yield return new object[] { x, y, TicTacToeCellValue.O };
                    }
                }
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

    }
}
