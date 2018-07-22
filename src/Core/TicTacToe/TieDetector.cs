namespace ThreadingExplore.Core.TicTacToe
{
    public class TieDetector
    {
        public static bool IsTied(
            TicTacToeBoard board)
        {
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    if (board.GetCellValue(x, y) == TicTacToeCellValue.Blank)
                        return false;
                }
            }

            return true;
        }
    }
}