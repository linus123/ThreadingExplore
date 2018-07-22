namespace ThreadingExplore.Core.TicTacToe
{
    public class TieDetector
    {
        public static bool IsTied(
            TicTacToeBoard board)
        {
            var locations = TicTacToeBoard.GetAllLocations();

            foreach (var location in locations)
            {
                if (board.GetCellValue(location) == TicTacToeCellValue.Blank)
                    return false;
            }

            return true;
        }
    }
}