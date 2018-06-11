namespace ThreadingExplore.Core.TicTacToe
{
    public class TicTacToeGame
    {
        public TicTacToeGame(
            string[,] grid = null)
        {
        }

        public CellValue GetCellValue(
            int x,
            int y)
        {
            return CellValue.Blank;
        }

        public enum CellValue
        {
            Blank,
            X,
            O
        }
    }
}