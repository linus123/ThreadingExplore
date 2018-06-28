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
            var hasHoisontalWin = HasHoisontalWin(CellValue.X);

            if (hasHoisontalWin.IsWon)
                return hasHoisontalWin;

            var hoisontalWin = HasHoisontalWin(CellValue.O);

            if (hoisontalWin.IsWon)
                return hoisontalWin;

            var hasVerticalWin = HasVerticalWin(CellValue.X);

            if (hasVerticalWin.IsWon)
                return hasVerticalWin;

            var verticalWin = HasVerticalWin(CellValue.O);

            if (verticalWin.IsWon)
                return verticalWin;

            var diaginal1WinXStatus = GetDiaginal1WinStatus(CellValue.X);

            if (diaginal1WinXStatus.IsWon)
                return diaginal1WinXStatus;

            var diaginal1WinOStatus = GetDiaginal1WinStatus(CellValue.O);

            if (diaginal1WinOStatus.IsWon)
                return diaginal1WinOStatus;

            var diaginal2WinXStatus = GetDiaginal2WinStatus(CellValue.X);

            if (diaginal2WinXStatus.IsWon)
                return diaginal2WinXStatus;

            var diaginal2WinOStatus = GetDiaginal2WinStatus(CellValue.O);

            if (diaginal2WinOStatus.IsWon)
                return diaginal2WinOStatus;

            return WinStatus.NotWon;
        }

        public class WinStatus
        {
            public static WinStatus NotWon = new WinStatus(false, null);

            public bool IsWon { get; }
            public string Message { get; }

            public WinStatus(
                bool isWon,
                string message)
            {
                Message = message;
                IsWon = isWon;
            }
        }

        private WinStatus GetDiaginal1WinStatus(CellValue value)
        {
            if (_gameBoard[0, 0] == value
                && _gameBoard[1, 1] == value
                && _gameBoard[2, 2] == value)
            {
                return new WinStatus(true, $"{value} has won with diaginal 1 win.");
            }

            return WinStatus.NotWon;
        }

        private WinStatus GetDiaginal2WinStatus(CellValue value)
        {
            if (_gameBoard[2, 0] == value
                && _gameBoard[1, 1] == value
                && _gameBoard[0, 2] == value)
            {
                return new WinStatus(true, $"{value} has won with diaginal 2 win.");
            }

            return WinStatus.NotWon;
        }

        private WinStatus HasHoisontalWin(CellValue cellValue)
        {
            for (int y = 0; y < 3; y++)
            {
                if (_gameBoard[0, y] == cellValue
                    && _gameBoard[1, y] == cellValue
                    && _gameBoard[2, y] == cellValue)
                    return new WinStatus(true, $"{cellValue} has won with horizontal win at y = {y}.");
            }

            return WinStatus.NotWon;
        }

        private WinStatus HasVerticalWin(CellValue cellValue)
        {
            for (int x = 0; x < 3; x++)
            {
                if (_gameBoard[x, 0] == cellValue
                    && _gameBoard[x, 1] == cellValue
                    && _gameBoard[x, 2] == cellValue)
                    return new WinStatus(true, $"{cellValue} has won with vertical win at x = {x}.");
            }

            return WinStatus.NotWon;
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