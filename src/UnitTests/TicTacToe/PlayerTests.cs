using System;
using System.Collections.Generic;
using FluentAssertions;
using ThreadingExplore.Core.TicTacToe;
using Xunit;

namespace ThreadingExplore.UnitTests.TicTacToe
{
    public class PlayerTests
    {
        [Theory]
        [InlineData(TicTacToeCellValue.O)]
        [InlineData(TicTacToeCellValue.X)]
        public void ShouldPickNextBlankSpace(
            TicTacToeCellValue cellValue)
        {
            var grid = new string[]
            {
                "---",
                "---",
                "---",
            };

            var board = new TicTacToeBoard(grid);

            var player = new Player(cellValue);

            player.MakeNextMove(board);

            board.GetCellValue(0, 0).Should().Be(cellValue);
        }

        [Theory]
        [MemberData(nameof(GetEveryBockableCombination), parameters: 3)]
        public void ShouldMakeTopRowBlock(
            string inputRow,
            string expectedRow,
            TicTacToeCellValue cellValue)
        {
            var grid = new string[]
            {
                inputRow,
                "---",
                "---",
            };

            var board = new TicTacToeBoard(grid);

            var player = new Player(cellValue);

            player.MakeNextMove(board);

            var stringBoard = board.GetStringBoard();

            stringBoard[0].Should().Be(expectedRow);
            stringBoard[1].Should().Be("---");
            stringBoard[2].Should().Be("---");
        }

        [Theory]
        [MemberData(nameof(GetEveryBockableCombination), parameters: 3)]
        public void ShouldMakeMiddleRowBlock(
            string inputRow,
            string expectedRow,
            TicTacToeCellValue cellValue)
        {
            var grid = new string[]
            {
                "---",
                inputRow,
                "---",
            };

            var board = new TicTacToeBoard(grid);

            var player = new Player(cellValue);

            player.MakeNextMove(board);

            var stringBoard = board.GetStringBoard();

            stringBoard[0].Should().Be("---");
            stringBoard[1].Should().Be(expectedRow);
            stringBoard[2].Should().Be("---");
        }

        [Theory]
        [MemberData(nameof(GetEveryBockableCombination), parameters: 3)]
        public void ShouldMakeBottomRowBlock(
            string inputRow,
            string expectedRow,
            TicTacToeCellValue cellValue)
        {
            var grid = new string[]
            {
                "---",
                "---",
                inputRow,
            };

            var board = new TicTacToeBoard(grid);

            var player = new Player(cellValue);

            player.MakeNextMove(board);

            var stringBoard = board.GetStringBoard();

            stringBoard[0].Should().Be("---");
            stringBoard[1].Should().Be("---");
            stringBoard[2].Should().Be(expectedRow);
        }

        // **

        [Theory]
        [MemberData(nameof(GetEveryBockableCombination), parameters: 3)]
        public void ShouldMakeLeftRowBlock(
            string inputRow,
            string expectedRow,
            TicTacToeCellValue cellValue)
        {
            var grid = new string[]
            {
                inputRow[0] + "--",
                inputRow[1] + "--",
                inputRow[2] + "--",
            };

            var board = new TicTacToeBoard(grid);

            var player = new Player(cellValue);

            player.MakeNextMove(board);

            var stringBoard = board.GetStringBoard();
            stringBoard[0].Should().Be(expectedRow[0] + "--");
            stringBoard[1].Should().Be(expectedRow[1] + "--");
            stringBoard[2].Should().Be(expectedRow[2] + "--");
        }

        [Theory]
        [MemberData(nameof(GetEveryBockableCombination), parameters: 3)]
        public void ShouldMakeCenterRowBlock(
            string inputRow,
            string expectedRow,
            TicTacToeCellValue cellValue)
        {
            var grid = new string[]
            {
                "-" + inputRow[0] + "-",
                "-" + inputRow[1] + "-",
                "-" + inputRow[2] + "-",
            };

            var board = new TicTacToeBoard(grid);

            var player = new Player(cellValue);

            player.MakeNextMove(board);

            var stringBoard = board.GetStringBoard();

            stringBoard[0].Should().Be("-" + expectedRow[0] + "-");
            stringBoard[1].Should().Be("-" + expectedRow[1] + "-");
            stringBoard[2].Should().Be("-" + expectedRow[2] + "-");
        }

        [Theory]
        [MemberData(nameof(GetEveryBockableCombination), parameters: 3)]
        public void ShouldMakeRightRowBlock(
            string inputRow,
            string expectedRow,
            TicTacToeCellValue cellValue)
        {
            var grid = new string[]
            {
                "--" + inputRow[0],
                "--" + inputRow[1],
                "--" + inputRow[2],
            };

            var board = new TicTacToeBoard(grid);

            var player = new Player(cellValue);

            player.MakeNextMove(board);

            var stringBoard = board.GetStringBoard();

            stringBoard[0].Should().Be("--" + expectedRow[0]);
            stringBoard[1].Should().Be("--" + expectedRow[1]);
            stringBoard[2].Should().Be("--" + expectedRow[2]);
        }

        [Theory]
        [MemberData(nameof(GetEveryBockableCombination), parameters: 3)]
        public void ShouldMakeDiagonalBlock1(
            string inputRow,
            string expectedRow,
            TicTacToeCellValue cellValue)
        {
            var grid = new string[]
            {
                inputRow[0] + "--",
                "-" + inputRow[1] + "-",
                "--" + inputRow[2],
            };

            var board = new TicTacToeBoard(grid);

            var player = new Player(cellValue);

            player.MakeNextMove(board);

            var stringBoard = board.GetStringBoard();

            stringBoard[0].Should().Be(expectedRow[0] + "--");
            stringBoard[1].Should().Be("-" + expectedRow[1] + "-");
            stringBoard[2].Should().Be("--" + expectedRow[2]);
        }

        [Theory]
        [MemberData(nameof(GetEveryBockableCombination), parameters: 3)]
        public void ShouldMakeDiagonalBlock2(
            string inputRow,
            string expectedRow,
            TicTacToeCellValue cellValue)
        {
            var grid = new string[]
            {
                "--" + inputRow[0],
                "-" + inputRow[1] + "-",
                inputRow[2] + "--",
            };

            var board = new TicTacToeBoard(grid);

            var player = new Player(cellValue);

            player.MakeNextMove(board);

            var stringBoard = board.GetStringBoard();

            stringBoard[0].Should().Be("--" + expectedRow[0]);
            stringBoard[1].Should().Be("-" + expectedRow[1] + "-");
            stringBoard[2].Should().Be(expectedRow[2] + "--");
        }


        public static IEnumerable<object[]> GetEveryBockableCombination(int numTests)
        {
            yield return new object[] { "XX-", "XXO", TicTacToeCellValue.O };
            yield return new object[] { "X-X", "XOX", TicTacToeCellValue.O };
            yield return new object[] { "-XX", "OXX", TicTacToeCellValue.O };

            yield return new object[] { "OO-", "OOX", TicTacToeCellValue.X };
            yield return new object[] { "O-O", "OXO", TicTacToeCellValue.X };
            yield return new object[] { "-OO", "XOO", TicTacToeCellValue.X };
        }

    }
}