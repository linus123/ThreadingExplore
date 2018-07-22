﻿using FluentAssertions;
using ThreadingExplore.Core.TicTacToe;
using Xunit;

namespace ThreadingExplore.UnitTests.TicTacToe
{
    public class TicTacToeGameForWinDetectionTests
    {
        [Fact]
        public void IsWonShouldBeFalseForBlankGrid()
        {
            var game = new TicTacToeGame();

            var winStatus = game.GetWinStatus();

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

            var winStatus = game.GetWinStatus();

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
            var game = new TicTacToeGame();

            game.SetCellValue(0, y, cellValue);
            game.SetCellValue(1, y, cellValue);
            game.SetCellValue(2, y, cellValue);

            var winStatus = game.GetWinStatus();

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
            var game = new TicTacToeGame();

            game.SetCellValue(x, 0, cellValue);
            game.SetCellValue(x, 1, cellValue);
            game.SetCellValue(x, 2, cellValue);

            var winStatus = game.GetWinStatus();

            winStatus.IsWon.Should().BeTrue();
            winStatus.WinMessage.Should().Be($"Column win for {cellValue} on column {x + 1}");
        }
    }
}