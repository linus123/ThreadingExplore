using System;

namespace ThreadingExplore.Core.GameOfLife
{
    public class GameOfLifeGrid
    {
        private readonly CellStatus[,] _grid;

        public GameOfLifeGrid()
        {
            _grid = new CellStatus[3, 3];

            IntiGrid();
        }

        private void IntiGrid()
        {
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    _grid[x, y] = CellStatus.NotAlive;
                }
            }
        }

        public CellStatus GetCellStatus(int x, int y)
        {
            return _grid[x, y];
        }

        public void SetCellStatus(int x, int y, CellStatus cellStatus)
        {
            _grid[x, y] = cellStatus;
        }

        public void SetGrid(string[] stringGrid)
        {
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    if (stringGrid[y][x] == '*')
                    {
                        SetCellStatus(x, y, CellStatus.Alive);
                    }
                    else
                    {
                        SetCellStatus(x, y, CellStatus.NotAlive);
                    }
                }
            }
        }

        public bool IsGridEqual(string[] stringGrid)
        {
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    if (stringGrid[y][x] == '*')
                    {
                        if (GetCellStatus(x, y) != CellStatus.Alive)
                            return false;
                    }
                    else
                    {
                        if (GetCellStatus(x, y) != CellStatus.NotAlive)
                            return false;
                    }
                }
            }

            return true;
        }
    }

    public enum CellStatus
    {
        Alive,
        NotAlive
    }
}