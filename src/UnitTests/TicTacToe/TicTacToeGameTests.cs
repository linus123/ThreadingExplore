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
            TicTacToeGame.CellValue cellValue)
        {
            var game = new TicTacToeGame();

            game.SetCellValue(x, y, cellValue);
            game.GetCellValue(x, y).Should().Be(cellValue);

            game.SetCellValue(x, y, TicTacToeGame.CellValue.Blank);
            game.GetCellValue(x, y).Should().Be(TicTacToeGame.CellValue.Blank);

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

            game.GetCellValue(0, 0).Should().Be(TicTacToeGame.CellValue.X);
            game.GetCellValue(1, 0).Should().Be(TicTacToeGame.CellValue.Blank);
            game.GetCellValue(1, 1).Should().Be(TicTacToeGame.CellValue.O);
            game.GetCellValue(0, 2).Should().Be(TicTacToeGame.CellValue.O);
            game.GetCellValue(1, 2).Should().Be(TicTacToeGame.CellValue.Blank);
            game.GetCellValue(2, 2).Should().Be(TicTacToeGame.CellValue.X);
        }

        [Fact]
        public void IsWonShouldBeFalseForBlankGrid()
        {
            var game = new TicTacToeGame();

            var winStatus = game.GetIsWon();
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

            var game = new TicTacToeGame(grid);

            var winStatus = game.GetIsWon();
            winStatus.IsWon.Should().BeFalse();
        }

        [Theory]
        [InlineData(0, TicTacToeGame.CellValue.X)]
        [InlineData(1, TicTacToeGame.CellValue.X)]
        [InlineData(2, TicTacToeGame.CellValue.X)]
        [InlineData(0, TicTacToeGame.CellValue.O)]
        [InlineData(1, TicTacToeGame.CellValue.O)]
        [InlineData(2, TicTacToeGame.CellValue.O)]
        public void IsWonShouldBeTrueForHorizonalWin(
            int y,
            TicTacToeGame.CellValue cellValue)
        {
            var game = new TicTacToeGame();

            game.SetCellValue(0, y, cellValue);
            game.SetCellValue(1, y, cellValue);
            game.SetCellValue(2, y, cellValue);

            var winStatus = game.GetIsWon();
            winStatus.IsWon.Should().BeTrue();
        }

        [Theory]
        [InlineData(0, TicTacToeGame.CellValue.X)]
        [InlineData(1, TicTacToeGame.CellValue.X)]
        [InlineData(2, TicTacToeGame.CellValue.X)]
        [InlineData(0, TicTacToeGame.CellValue.O)]
        [InlineData(1, TicTacToeGame.CellValue.O)]
        [InlineData(2, TicTacToeGame.CellValue.O)]
        public void IsWonShouldBeTrueForVerticalWin(
            int x,
            TicTacToeGame.CellValue cellValue)
        {
            var game = new TicTacToeGame();

            game.SetCellValue(x, 0, cellValue);
            game.SetCellValue(x, 1, cellValue);
            game.SetCellValue(x, 2, cellValue);

            var winStatus = game.GetIsWon();
            winStatus.IsWon.Should().BeTrue();
        }

        [Theory]
        [InlineData(TicTacToeGame.CellValue.X)]
        [InlineData(TicTacToeGame.CellValue.O)]
        public void IsWonShouldBeTrueForDiagonal1Win(
            TicTacToeGame.CellValue cellValue)
        {
            var game = new TicTacToeGame();

            game.SetCellValue(0, 0, cellValue);
            game.SetCellValue(1, 1, cellValue);
            game.SetCellValue(2, 2, cellValue);

            var winStatus = game.GetIsWon();
            winStatus.IsWon.Should().BeTrue();
        }

        [Theory]
        [InlineData(TicTacToeGame.CellValue.X)]
        [InlineData(TicTacToeGame.CellValue.O)]
        public void IsWonShouldBeTrueForDiagonal2Win(
            TicTacToeGame.CellValue cellValue)
        {
            var game = new TicTacToeGame();

            game.SetCellValue(2, 0, cellValue);
            game.SetCellValue(1, 1, cellValue);
            game.SetCellValue(0, 2, cellValue);

            var winStatus = game.GetIsWon();
            winStatus.IsWon.Should().BeTrue();
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
