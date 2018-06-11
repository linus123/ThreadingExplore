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

        public bool IsWon
        {
            get { return false; }
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