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

        [Theory]
        [ClassData(typeof(EachCellWithXandO))]
        public void SetCellValueShouldChangeCellValues(
            int x,
            int y,
            TicTacToeGame.CellValue cellValue)
        {
            var game = new TicTacToeGame();

            game.SetCellValue(x, y, cellValue);
            game.GetCellValue(x, y).Should().Be(cellValue);

            game.SetCellValue(x, y, TicTacToeGame.CellValue.Blank);
            game.GetCellValue(x, y).Should().Be(TicTacToeGame.CellValue.Blank);

            AssertAllCellsAreBlank(game);
        }

        public class EachCellWithXandO : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                for (int x = 0; x < 3; x++)
                {
                    for (int y = 0; y < 3; y++)
                    {
                        yield return new object[] { x, y, TicTacToeGame.CellValue.X };
                        yield return new object[] { x, y, TicTacToeGame.CellValue.O };
                    }
                }
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
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
    }
}
