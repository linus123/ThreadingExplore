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
    }
}