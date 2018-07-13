using System;

namespace ThreadingExplore.Core.TicTacToe
{
    public class TicTacToeGame
    {
        private readonly CellValue[,] _gameBoard;

        public TicTacToeGame(
            string[] grid = null)
        {
            _gameBoard = new CellValue[3, 3];

            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    _gameBoard[x, y] = CellValue.Blank;

                    if (grid != null)
                    {
                        if (grid[y][x] == 'X')
                            _gameBoard[x, y] = CellValue.X;

                        if (grid[y][x] == 'O')
                            _gameBoard[x, y] = CellValue.O;

                    }
                }
            }
        }

        private WinStatus GetColumnWinStatus(
            CellValue cellValue)
        {
            for (int x = 0; x < 3; x++)
            {
                if (_gameBoard[x, 0] == cellValue
                    && _gameBoard[x, 1] == cellValue
                    && _gameBoard[x, 2] == cellValue)
                {
                    var message = $"Column win for {cellValue} on column {x + 1}";
                    return WinStatus.CreateAsWin(message);
                }
            }

            return WinStatus.CreateAsNoWin();
        }

        private WinStatus GetRowWinStatus(
            CellValue cellValue)
        {
            for (int y = 0; y < 3; y++)
            {
                if (_gameBoard[0, y] == cellValue
                    && _gameBoard[1, y] == cellValue
                    && _gameBoard[2, y] == cellValue)
                {
                    var message = $"Row win for {cellValue} on row {y + 1}";
                    return WinStatus.CreateAsWin(message);
                }
            }

            return WinStatus.CreateAsNoWin();
        }

        public WinStatus GetWinStatus()
        {
            var columnWinStatusX = GetColumnWinStatus(CellValue.X);

            if (columnWinStatusX.IsWon)
                return columnWinStatusX;

            var columnWinStatusO = GetColumnWinStatus(CellValue.O);

            if (columnWinStatusO.IsWon)
                return columnWinStatusO;

            var rowWinStatusX = GetRowWinStatus(CellValue.X);

            if (rowWinStatusX.IsWon)
                return rowWinStatusX;

            var rowWinStatusO = GetRowWinStatus(CellValue.O);

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
            CellValue cellValue)
        {
            _gameBoard[x, y] = cellValue;
        }

        public CellValue GetCellValue(
            int x,
            int y)
        {
            return _gameBoard[x, y];
        }

        public enum CellValue
        {
            Blank,
            X,
            O
        }

        public string[] GetStringBoard()
        {
            var returnBoard = new string[3];

            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    if (_gameBoard[x, y] == CellValue.Blank)
                        returnBoard[y] += "-";
                    else
                        returnBoard[y] += _gameBoard[x, y];
                }
            }

            return returnBoard;
        }

        private int AddWithAdjust(int x, int addVal)
        {
            var n1 = x + addVal;

            if (n1 >= 3)
                n1 = n1 - 3;

            return n1;
        }

        public void MakeNextMoveFor(CellValue turnCellValue)
        {
            var opposingCellValue = CellValue.X;

            if (turnCellValue == CellValue.X)
                opposingCellValue = CellValue.O;

            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    if (_gameBoard[AddWithAdjust(x, 1), y] == opposingCellValue
                        && _gameBoard[AddWithAdjust(x, 2), y] == opposingCellValue)
                    {
                        _gameBoard[AddWithAdjust(x, 0), y] = turnCellValue;
                        return;
                    }
                }
            }

            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    if (_gameBoard[x, AddWithAdjust(y, 1)] == opposingCellValue
                        && _gameBoard[x, AddWithAdjust(y, 2)] == opposingCellValue)
                    {
                        _gameBoard[x, AddWithAdjust(y, 0)] = turnCellValue;
                        return;
                    }
                }
            }

            for (int n = 0; n < 3; n++)
            {
                if (_gameBoard[AddWithAdjust(n, 0), AddWithAdjust(n, 0)] == opposingCellValue
                    && _gameBoard[AddWithAdjust(n, 1), AddWithAdjust(n, 1)] == opposingCellValue)
                {
                    _gameBoard[AddWithAdjust(n, 2), AddWithAdjust(n, 2)] = turnCellValue;
                    return;
                }
            }

            // **

            if (_gameBoard[2, 0] == opposingCellValue
                && _gameBoard[1, 1] == opposingCellValue)
            {
                _gameBoard[0, 2] = turnCellValue;
                return;
            }

            if (_gameBoard[2, 0] == opposingCellValue
                && _gameBoard[0, 2] == opposingCellValue)
            {
                _gameBoard[1, 1] = turnCellValue;
                return;
            }

            if (_gameBoard[0, 2] == opposingCellValue
                && _gameBoard[1, 1] == opposingCellValue)
            {
                _gameBoard[2, 0] = turnCellValue;
                return;
            }


        }
    }
}