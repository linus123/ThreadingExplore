namespace ThreadingExplore.Core.TicTacToe
{
    public class Player
    {
        private readonly TicTacToeCellValue _cellValue;

        public Player(
            TicTacToeCellValue cellValue)
        {
            _cellValue = cellValue;
        }

        public void MakeNextMoveFor(
            TicTacToeBoard board)
        {
            var opposingCellValue = TicTacToeCellValue.X;

            if (_cellValue == TicTacToeCellValue.X)
                opposingCellValue = TicTacToeCellValue.O;

            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    if (board.GetCellValue(AddWithAdjust(x, 1), y) == opposingCellValue
                        && board.GetCellValue(AddWithAdjust(x, 2), y) == opposingCellValue)
                    {
                        board.SetCellValue(AddWithAdjust(x, 0), y, _cellValue);
                        return;
                    }
                }
            }

            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    if (board.GetCellValue(x, AddWithAdjust(y, 1)) == opposingCellValue
                        && board.GetCellValue(x, AddWithAdjust(y, 2)) == opposingCellValue)
                    {
                        board.SetCellValue(x, AddWithAdjust(y, 0), _cellValue);
                        return;
                    }
                }
            }

            for (int n = 0; n < 3; n++)
            {
                if (board.GetCellValue(AddWithAdjust(n, 0), AddWithAdjust(n, 0)) == opposingCellValue
                    && board.GetCellValue(AddWithAdjust(n, 1), AddWithAdjust(n, 1)) == opposingCellValue)
                {
                    board.SetCellValue(AddWithAdjust(n, 2), AddWithAdjust(n, 2), _cellValue);
                    return;
                }
            }

            // **

            if (board.GetCellValue(2, 0) == opposingCellValue
                && board.GetCellValue(1, 1) == opposingCellValue)
            {
                board.SetCellValue(0, 2, _cellValue);
                return;
            }

            if (board.GetCellValue(2, 0) == opposingCellValue
                && board.GetCellValue(0, 2) == opposingCellValue)
            {
                board.SetCellValue(1, 1, _cellValue);
                return;
            }

            if (board.GetCellValue(0, 2) == opposingCellValue
                && board.GetCellValue(1, 1) == opposingCellValue)
            {
                board.SetCellValue(2, 0, _cellValue);
                return;
            }
        }

        private int AddWithAdjust(int x, int addVal)
        {
            var n1 = x + addVal;

            if (n1 >= 3)
                n1 = n1 - 3;

            return n1;
        }

    }
}