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
                if (board.GetCellValue(x, 0) == cellValue
                    && board.GetCellValue(x, 1) == cellValue
                    && board.GetCellValue(x, 2) == cellValue)
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
                if (board.GetCellValue(0, y) == cellValue
                    && board.GetCellValue(1, y) == cellValue
                    && board.GetCellValue(2, y) == cellValue)
                {
                    var message = $"Row win for {cellValue} on row {y + 1}";
                    return WinStatus.CreateAsWin(message);
                }
            }

            return WinStatus.CreateAsNoWin();
        }

    }
}