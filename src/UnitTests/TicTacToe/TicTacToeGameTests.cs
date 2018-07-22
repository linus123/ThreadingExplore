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
            var game = new TicTacToeGame();

            AssertAllCellsAreBlank(game);
        }

        [Theory]
        [ClassData(typeof(EachCellWithXandO))]
        public void SetCellValueShouldChangeCellValues(
            int x,
            int y,
            TicTacToeCellValue cellValue)
        {
            var game = new TicTacToeGame();

            game.SetCellValue(x, y, cellValue);
            game.GetCellValue(x, y).Should().Be(cellValue);

            game.SetCellValue(x, y, TicTacToeCellValue.Blank);
            game.GetCellValue(x, y).Should().Be(TicTacToeCellValue.Blank);

            AssertAllCellsAreBlank(game);
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

            var game = new TicTacToeGame(grid);

            AssertAllCellsAreBlank(game);
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

            var game = new TicTacToeGame(grid);

            game.GetCellValue(0, 0).Should().Be(TicTacToeCellValue.X);
            game.GetCellValue(1, 0).Should().Be(TicTacToeCellValue.Blank);
            game.GetCellValue(1, 1).Should().Be(TicTacToeCellValue.O);
            game.GetCellValue(0, 2).Should().Be(TicTacToeCellValue.O);
            game.GetCellValue(1, 2).Should().Be(TicTacToeCellValue.Blank);
            game.GetCellValue(2, 2).Should().Be(TicTacToeCellValue.X);
        }

        [Fact]
        public void GetStringBoardShouldReturnLayoutOfBoardWithAllBlanks()
        {
            var ticTacToeGame = new TicTacToeGame();

            var stringBoard = ticTacToeGame.GetStringBoard();

            stringBoard[0].Should().Be("---");
            stringBoard[1].Should().Be("---");
            stringBoard[2].Should().Be("---");
        }

        [Fact]
        public void GetStringBoardShouldReturnLayoutOfBoardWithMixOfXAndOs()
        {
            var ticTacToeGame = new TicTacToeGame();

            ticTacToeGame.SetCellValue(0, 0, TicTacToeCellValue.X);
            ticTacToeGame.SetCellValue(1, 0, TicTacToeCellValue.O);
            ticTacToeGame.SetCellValue(1, 1, TicTacToeCellValue.O);
            ticTacToeGame.SetCellValue(1, 2, TicTacToeCellValue.X);

            var stringBoard = ticTacToeGame.GetStringBoard();

            stringBoard[0].Should().Be("XO-");
            stringBoard[1].Should().Be("-O-");
            stringBoard[2].Should().Be("-X-");
        }


        private static void AssertAllCellsAreBlank(TicTacToeGame game)
        {
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    game.GetCellValue(x, y).Should().Be(TicTacToeCellValue.Blank);
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
