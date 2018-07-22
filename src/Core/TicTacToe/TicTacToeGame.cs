namespace ThreadingExplore.Core.TicTacToe
{
    public class TicTacToeGame
    {
        private readonly TicTacToeBoard _ticTacToeBoard;

        public TicTacToeGame(
            string[] grid = null)
        {
            _ticTacToeBoard = new TicTacToeBoard(grid);
        }

        private WinStatus GetColumnWinStatus(
            TicTacToeCellValue cellValue)
        {
            for (int x = 0; x < 3; x++)
            {
                if (_ticTacToeBoard.GetCellValue(x, 0) == cellValue
                    && _ticTacToeBoard.GetCellValue(x, 1) == cellValue
                    && _ticTacToeBoard.GetCellValue(x, 2) == cellValue)
                {
                    var message = $"Column win for {cellValue} on column {x + 1}";
                    return WinStatus.CreateAsWin(message);
                }
            }

            return WinStatus.CreateAsNoWin();
        }

        private WinStatus GetRowWinStatus(
            TicTacToeCellValue cellValue)
        {
            for (int y = 0; y < 3; y++)
            {
                if (_ticTacToeBoard.GetCellValue(0, y) == cellValue
                    && _ticTacToeBoard.GetCellValue(1, y) == cellValue
                    && _ticTacToeBoard.GetCellValue(2, y) == cellValue)
                {
                    var message = $"Row win for {cellValue} on row {y + 1}";
                    return WinStatus.CreateAsWin(message);
                }
            }

            return WinStatus.CreateAsNoWin();
        }

        public WinStatus GetWinStatus()
        {
            var columnWinStatusX = GetColumnWinStatus(TicTacToeCellValue.X);

            if (columnWinStatusX.IsWon)
                return columnWinStatusX;

            var columnWinStatusO = GetColumnWinStatus(TicTacToeCellValue.O);

            if (columnWinStatusO.IsWon)
                return columnWinStatusO;

            var rowWinStatusX = GetRowWinStatus(TicTacToeCellValue.X);

            if (rowWinStatusX.IsWon)
                return rowWinStatusX;

            var rowWinStatusO = GetRowWinStatus(TicTacToeCellValue.O);

            if (rowWinStatusO.IsWon)
                return rowWinStatusO;

            return WinStatus.CreateAsNoWin();
        }

        public class WinStatus
        {
            public static WinStatus CreateAsWin(
                string message)
            {
                return new WinStatus(true)
                {
                    WinMessage = message
                };
            }

            public static WinStatus CreateAsNoWin()
            {
                return new WinStatus(false);
            }

            private WinStatus(bool isWon)
            {
                IsWon = isWon;
            }

            public bool IsWon { get; }
            public string WinMessage { get; private set; }
        }


        public void SetCellValue(
            int x,
            int y,
            TicTacToeCellValue cellValue)
        {
            _ticTacToeBoard.SetCellValue(x, y, cellValue);
        }

        public TicTacToeCellValue GetCellValue(
            int x,
            int y)
        {
            return _ticTacToeBoard.GetCellValue(x, y);
        }

        public string[] GetStringBoard()
        {
            return _ticTacToeBoard.GetStringBoard();
        }

        private int AddWithAdjust(int x, int addVal)
        {
            var n1 = x + addVal;

            if (n1 >= 3)
                n1 = n1 - 3;

            return n1;
        }

        public void MakeNextMoveFor(TicTacToeCellValue turnCellValue)
        {
            var opposingCellValue = TicTacToeCellValue.X;

            if (turnCellValue == TicTacToeCellValue.X)
                opposingCellValue = TicTacToeCellValue.O;

            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    if (_ticTacToeBoard.GetCellValue(AddWithAdjust(x, 1), y) == opposingCellValue
                        && _ticTacToeBoard.GetCellValue(AddWithAdjust(x, 2), y) == opposingCellValue)
                    {
                        _ticTacToeBoard.SetCellValue(AddWithAdjust(x, 0), y, turnCellValue);
                        return;
                    }
                }
            }

            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    if (_ticTacToeBoard.GetCellValue(x, AddWithAdjust(y, 1)) == opposingCellValue
                        && _ticTacToeBoard.GetCellValue(x, AddWithAdjust(y, 2)) == opposingCellValue)
                    {
                        _ticTacToeBoard.SetCellValue(x, AddWithAdjust(y, 0), turnCellValue);
                        return;
                    }
                }
            }

            for (int n = 0; n < 3; n++)
            {
                if (_ticTacToeBoard.GetCellValue(AddWithAdjust(n, 0), AddWithAdjust(n, 0)) == opposingCellValue
                    && _ticTacToeBoard.GetCellValue(AddWithAdjust(n, 1), AddWithAdjust(n, 1)) == opposingCellValue)
                {
                    _ticTacToeBoard.SetCellValue(AddWithAdjust(n, 2), AddWithAdjust(n, 2), turnCellValue);
                    return;
                }
            }

            // **

            if (_ticTacToeBoard.GetCellValue(2, 0) == opposingCellValue
                && _ticTacToeBoard.GetCellValue(1, 1) == opposingCellValue)
            {
                _ticTacToeBoard.SetCellValue(0, 2, turnCellValue);
                return;
            }

            if (_ticTacToeBoard.GetCellValue(2, 0) == opposingCellValue
                && _ticTacToeBoard.GetCellValue(0, 2) == opposingCellValue)
            {
                _ticTacToeBoard.SetCellValue(1, 1, turnCellValue);
                return;
            }

            if (_ticTacToeBoard.GetCellValue(0, 2) == opposingCellValue
                && _ticTacToeBoard.GetCellValue(1, 1) == opposingCellValue)
            {
                _ticTacToeBoard.SetCellValue(2, 0, turnCellValue);
                return;
            }
        }
    }
}