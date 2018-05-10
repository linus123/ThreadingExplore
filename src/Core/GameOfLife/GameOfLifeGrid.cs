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
    }

    public enum CellStatus
    {
        Alive,
        NotAlive
    }
}