using System.Collections.Generic;
using FluentAssertions;
using ThreadingExplore.Core.TicTacToe;
using Xunit;

namespace ThreadingExplore.UnitTests.TicTacToe
{
    public class TicTacToeGameForMakeNextMoveTests
    {
        [Theory]
        [MemberData(nameof(GetEveryBockableCombination), parameters: 3)]
        public void ShouldMakeTopRowBlock(
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
        [MemberData(nameof(GetEveryBockableCombination), parameters: 3)]
        public void ShouldMakeMiddleRowBlock(
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
        [MemberData(nameof(GetEveryBockableCombination), parameters: 3)]
        public void ShouldMakeBottomRowBlock(
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

        // **

        [Theory]
        [MemberData(nameof(GetEveryBockableCombination), parameters: 3)]
        public void ShouldMakeLeftRowBlock(
            string inputRow,
            string expectedRow,
            TicTacToeGame.CellValue cellValue)
        {
            var grid = new string[]
            {
                inputRow[0] + "--",
                inputRow[1] + "--",
                inputRow[2] + "--",
            };

            var ticTacToeGame = new TicTacToeGame(grid);

            ticTacToeGame.MakeNextMoveFor(cellValue);

            var stringBoard = ticTacToeGame.GetStringBoard();

            stringBoard[0].Should().Be(expectedRow[0] + "--");
            stringBoard[1].Should().Be(expectedRow[1] + "--");
            stringBoard[2].Should().Be(expectedRow[2] + "--");
        }

        [Theory]
        [MemberData(nameof(GetEveryBockableCombination), parameters: 3)]
        public void ShouldMakeCenterRowBlock(
            string inputRow,
            string expectedRow,
            TicTacToeGame.CellValue cellValue)
        {
            var grid = new string[]
            {
                "-" + inputRow[0] + "-",
                "-" + inputRow[1] + "-",
                "-" + inputRow[2] + "-",
            };

            var ticTacToeGame = new TicTacToeGame(grid);

            ticTacToeGame.MakeNextMoveFor(cellValue);

            var stringBoard = ticTacToeGame.GetStringBoard();

            stringBoard[0].Should().Be("-" + expectedRow[0] + "-");
            stringBoard[1].Should().Be("-" + expectedRow[1] + "-");
            stringBoard[2].Should().Be("-" + expectedRow[2] + "-");
        }

        [Theory]
        [MemberData(nameof(GetEveryBockableCombination), parameters: 3)]
        public void ShouldMakeRightRowBlock(
            string inputRow,
            string expectedRow,
            TicTacToeGame.CellValue cellValue)
        {
            var grid = new string[]
            {
                "--" + inputRow[0],
                "--" + inputRow[1],
                "--" + inputRow[2],
            };

            var ticTacToeGame = new TicTacToeGame(grid);

            ticTacToeGame.MakeNextMoveFor(cellValue);

            var stringBoard = ticTacToeGame.GetStringBoard();

            stringBoard[0].Should().Be("--" + expectedRow[0]);
            stringBoard[1].Should().Be("--" + expectedRow[1]);
            stringBoard[2].Should().Be("--" + expectedRow[2]);
        }


        public static IEnumerable<object[]> GetEveryBockableCombination(int numTests)
        {
            yield return new object[] { "XX-", "XXO", TicTacToeGame.CellValue.O };
            yield return new object[] { "X-X", "XOX", TicTacToeGame.CellValue.O };
            yield return new object[] { "-XX", "OXX", TicTacToeGame.CellValue.O };

            yield return new object[] { "OO-", "OOX", TicTacToeGame.CellValue.X };
            yield return new object[] { "O-O", "OXO", TicTacToeGame.CellValue.X };
            yield return new object[] { "-OO", "XOO", TicTacToeGame.CellValue.X };
        }

    }
}