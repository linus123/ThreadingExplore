namespace ThreadingExplore.Core.TicTacToe
{
    public class WinDetector
    {
        public static WinStatus GetWinStatus(
            TicTacToeBoard board)
        {
            var columnWinStatusX = GetColumnWinStatus(
                TicTacToeCellValue.X,
                board);

            if (columnWinStatusX.IsWon)
                return columnWinStatusX;

            var columnWinStatusO = GetColumnWinStatus(
                TicTacToeCellValue.O,
                board);

            if (columnWinStatusO.IsWon)
                return columnWinStatusO;

            var rowWinStatusX = GetRowWinStatus(
                TicTacToeCellValue.X,
                board);

            if (rowWinStatusX.IsWon)
                return rowWinStatusX;

            var rowWinStatusO = GetRowWinStatus(
                TicTacToeCellValue.O, board);

            if (rowWinStatusO.IsWon)
                return rowWinStatusO;

            return WinStatus.CreateAsNoWin();
        }

        private static WinStatus GetColumnWinStatus(
            TicTacToeCellValue cellValue,
            TicTacToeBoard board)
        {
            for (int x = 0; x < 3; x++)
            {
                var verticalCells = board.GetVerticalCells(x);

                if (verticalCells[0] == cellValue
                    && verticalCells[1] == cellValue
                    && verticalCells[2] == cellValue)
                {
                    var message = $"Column win for {cellValue} on column {x + 1}";
                    return WinStatus.CreateAsWin(message);
                }
            }

            return WinStatus.CreateAsNoWin();
        }

        private static WinStatus GetRowWinStatus(
            TicTacToeCellValue cellValue,
            TicTacToeBoard board)
        {
            for (int y = 0; y < 3; y++)
            {
                var horizontalCells = board.GetHorizontalCells(y);

                if (horizontalCells[0] == cellValue
                    && horizontalCells[1] == cellValue
                    && horizontalCells[2] == cellValue)
                {
                    var message = $"Row win for {cellValue} on row {y + 1}";
                    return WinStatus.CreateAsWin(message);
                }
            }

            return WinStatus.CreateAsNoWin();
        }

    }
}