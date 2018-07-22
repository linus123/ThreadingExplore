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

        public CellValueWithLocation[] GetVerticalCells(
            int x)
        {
            return new[]
            {
                new CellValueWithLocation(_grid[x, 0], new TicTacToeLocation(x, 0)),
                new CellValueWithLocation(_grid[x, 1], new TicTacToeLocation(x, 1)),
                new CellValueWithLocation(_grid[x, 2], new TicTacToeLocation(x, 2)),
            };
        }

        public CellValueWithLocation[] GetHorizontalCells(
            int y)
        {
            return new[]
            {
                new CellValueWithLocation(_grid[0, y], new TicTacToeLocation(0, y)),
                new CellValueWithLocation(_grid[1, y], new TicTacToeLocation(1, y)),
                new CellValueWithLocation(_grid[2, y], new TicTacToeLocation(2, y))
            };
        }

        public CellValueWithLocation[] GetBackSlashDiagonalCells() // Backslash
        {
            return new[]
            {
                new CellValueWithLocation(_grid[0, 0], new TicTacToeLocation(0, 0)),
                new CellValueWithLocation(_grid[1, 1], new TicTacToeLocation(1, 1)),
                new CellValueWithLocation(_grid[2, 2], new TicTacToeLocation(2, 2))
            };
        }

        public CellValueWithLocation[] GetFrontSlashDiagonalCells() // ForwardSlash
        {
            return new[]
            {
                new CellValueWithLocation(_grid[2, 0], new TicTacToeLocation(2, 0)),
                new CellValueWithLocation(_grid[1, 1], new TicTacToeLocation(1, 1)),
                new CellValueWithLocation(_grid[0, 2], new TicTacToeLocation(0, 2))
            };
        }

        public void SetCellValue(
            int x,
            int y,
            TicTacToeCellValue cellValue)
        {
            _grid[x, y] = cellValue;
        }

        public void SetCellValue(
            ILocation location,
            TicTacToeCellValue cellValue)
        {
            _grid[location.X, location.Y] = cellValue;
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
