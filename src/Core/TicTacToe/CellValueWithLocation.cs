namespace ThreadingExplore.Core.TicTacToe
{
    public class CellValueWithLocation : ILocation
    {
        private readonly TicTacToeLocation _location;

        public CellValueWithLocation(
            TicTacToeCellValue cellValue,
            TicTacToeLocation location)
        {
            _location = location;
            CellValue = cellValue;
        }

        public int X
        {
            get { return _location.X; }
        }

        public int Y
        {
            get { return _location.Y; }
        }

        public TicTacToeCellValue CellValue { get; }

        public bool IsBlank
        {
            get { return CellValue == TicTacToeCellValue.Blank; }
        }
    }
}