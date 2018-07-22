namespace ThreadingExplore.Core.TicTacToe
{
    public class WinStatus
    {
        public static WinStatus CreateAsWin(
            string message)
        {
            return new WinStatus(true)
            {
                WinMessage = message
            };
        }

        public static WinStatus CreateAsNoWin()
        {
            return new WinStatus(false);
        }

        private WinStatus(bool isWon)
        {
            IsWon = isWon;
        }

        public bool IsWon { get; }
        public string WinMessage { get; private set; }
    }
}