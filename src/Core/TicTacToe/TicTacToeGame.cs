namespace ThreadingExplore.Core.TicTacToe
{
    public class TicTacToeGame
    {
        private readonly TicTacToeBoard _board;

        public TicTacToeGame(
            string[] grid = null)
        {
            _board = new TicTacToeBoard(grid);
        }

        public void SetCellValue(
            int x,
            int y,
            TicTacToeCellValue cellValue)
        {
            _board.SetCellValue(x, y, cellValue);
        }

        public TicTacToeCellValue GetCellValue(
            int x,
            int y)
        {
            return _board.GetCellValue(x, y);
        }

        public string[] GetStringBoard()
        {
            return _board.GetStringBoard();
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
                    if (_board.GetCellValue(AddWithAdjust(x, 1), y) == opposingCellValue
                        && _board.GetCellValue(AddWithAdjust(x, 2), y) == opposingCellValue)
                    {
                        _board.SetCellValue(AddWithAdjust(x, 0), y, turnCellValue);
                        return;
                    }
                }
            }

            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    if (_board.GetCellValue(x, AddWithAdjust(y, 1)) == opposingCellValue
                        && _board.GetCellValue(x, AddWithAdjust(y, 2)) == opposingCellValue)
                    {
                        _board.SetCellValue(x, AddWithAdjust(y, 0), turnCellValue);
                        return;
                    }
                }
            }

            for (int n = 0; n < 3; n++)
            {
                if (_board.GetCellValue(AddWithAdjust(n, 0), AddWithAdjust(n, 0)) == opposingCellValue
                    && _board.GetCellValue(AddWithAdjust(n, 1), AddWithAdjust(n, 1)) == opposingCellValue)
                {
                    _board.SetCellValue(AddWithAdjust(n, 2), AddWithAdjust(n, 2), turnCellValue);
                    return;
                }
            }

            // **

            if (_board.GetCellValue(2, 0) == opposingCellValue
                && _board.GetCellValue(1, 1) == opposingCellValue)
            {
                _board.SetCellValue(0, 2, turnCellValue);
                return;
            }

            if (_board.GetCellValue(2, 0) == opposingCellValue
                && _board.GetCellValue(0, 2) == opposingCellValue)
            {
                _board.SetCellValue(1, 1, turnCellValue);
                return;
            }

            if (_board.GetCellValue(0, 2) == opposingCellValue
                && _board.GetCellValue(1, 1) == opposingCellValue)
            {
                _board.SetCellValue(2, 0, turnCellValue);
                return;
            }
        }
    }
}