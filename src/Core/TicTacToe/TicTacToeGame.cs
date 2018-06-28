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

        public WinStatus GetIsWon()
        {
            if (HasHoisontalWin(CellValue.X))
                return new WinStatus(true);

            if (HasHoisontalWin(CellValue.O))
                return new WinStatus(true);

            if (HasVerticalWin(CellValue.X))
                return new WinStatus(true);

            if (HasVerticalWin(CellValue.O))
                return new WinStatus(true);

            if (HasDiaginal1Win(CellValue.X))
                return new WinStatus(true);

            if (HasDiaginal1Win(CellValue.O))
                return new WinStatus(true);

            if (HasDiaginal2Win(CellValue.X))
                return new WinStatus(true);

            if (HasDiaginal2Win(CellValue.O))
                return new WinStatus(true);

            return new WinStatus(false);
        }

        public class WinStatus
        {
            public bool IsWon { get; }

            public WinStatus(
                bool isWon)
            {
                IsWon = isWon;
            }
        }

        private bool HasDiaginal1Win(CellValue value)
        {
            return _gameBoard[0, 0] == value
                   && _gameBoard[1, 1] == value
                   && _gameBoard[2, 2] == value;
        }

        private bool HasDiaginal2Win(CellValue value)
        {
            return _gameBoard[2, 0] == value
                   && _gameBoard[1, 1] == value
                   && _gameBoard[0, 2] == value;
        }

        private bool HasHoisontalWin(CellValue cellValue)
        {
            for (int y = 0; y < 3; y++)
            {
                if (_gameBoard[0, y] == cellValue
                    && _gameBoard[1, y] == cellValue
                    && _gameBoard[2, y] == cellValue)
                    return true;
            }

            return false;
        }

        private bool HasVerticalWin(CellValue cellValue)
        {
            for (int x = 0; x < 3; x++)
            {
                if (_gameBoard[x, 0] == cellValue
                    && _gameBoard[x, 1] == cellValue
                    && _gameBoard[x, 2] == cellValue)
                    return true;
            }

            return false;
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
    }
}