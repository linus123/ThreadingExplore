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

        public WinStatus GetWinStatus()
        {
            for (int x = 0; x < 3; x++)
            {
                if (_gameBoard[x, 0] == CellValue.X
                    && _gameBoard[x, 1] == CellValue.X
                    && _gameBoard[x, 2] == CellValue.X)
                    return new WinStatus(true);
            }

            for (int x = 0; x < 3; x++)
            {
                if (_gameBoard[x, 0] == CellValue.O
                    && _gameBoard[x, 1] == CellValue.O
                    && _gameBoard[x, 2] == CellValue.O)
                    return new WinStatus(true);
            }

            for (int y = 0; y < 3; y++)
            {
                if (_gameBoard[0, y] == CellValue.X
                    && _gameBoard[1, y] == CellValue.X
                    && _gameBoard[2, y] == CellValue.X)
                    return new WinStatus(true);
            }

            for (int y = 0; y < 3; y++)
            {
                if (_gameBoard[0, y] == CellValue.O
                    && _gameBoard[1, y] == CellValue.O
                    && _gameBoard[2, y] == CellValue.O)
                    return new WinStatus(true);
            }

            return new WinStatus(false);
        }

        public class WinStatus
        {
            public WinStatus(bool isWon)
            {
                IsWon = isWon;
            }

            public bool IsWon { get; }
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