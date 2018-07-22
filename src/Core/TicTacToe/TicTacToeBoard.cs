using System.Collections.Generic;

namespace ThreadingExplore.Core.TicTacToe
{
    public class TicTacToeBoard
    {
        private readonly TicTacToeCellValue[,] _grid;

        public TicTacToeBoard(
            string[] grid = null)
        {
            _grid = new TicTacToeCellValue[3, 3];

            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    _grid[x, y] = TicTacToeCellValue.Blank;

                    if (grid != null)
                    {
                        if (grid[y][x] == 'X')
                            _grid[x, y] = TicTacToeCellValue.X;

                        if (grid[y][x] == 'O')
                            _grid[x, y] = TicTacToeCellValue.O;

                    }
                }
            }
        }

        public TicTacToeCellValue GetCellValue(
            TicTacToeLocation l)
        {
            return _grid[l.X, l.Y];
        }

        public bool IsCellBlank(
            TicTacToeLocation l)
        {
            return _grid[l.X, l.Y] == TicTacToeCellValue.Blank;
        }

        public TicTacToeCellValue GetCellValue(
            int x,
            int y)
        {
            return _grid[x, y];
        }

        public TicTacToeCellValue[] GetVerticalCells(
            int x)
        {
            return new[]
            {
                _grid[x, 0],
                _grid[x, 1],
                _grid[x, 2],
            };
        }

        public void SetCellValue(
            int x,
            int y,
            TicTacToeCellValue cellValue)
        {
            _grid[x, y] = cellValue;
        }

        public string[] GetStringBoard()
        {
            var returnBoard = new string[3];

            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    if (_grid[x, y] == TicTacToeCellValue.Blank)
                        returnBoard[y] += "-";
                    else
                        returnBoard[y] += _grid[x, y];
                }
            }

            return returnBoard;
        }

        public static TicTacToeLocation[] GetAllLocations()
        {
            var ticTacToeLocations = new List<TicTacToeLocation>();

            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    ticTacToeLocations.Add(new TicTacToeLocation(x, y));
                }
            }

            return ticTacToeLocations.ToArray();
        }
    }
}
