using ThreadingExplore.Core.GameOfLife;
using Xunit;

namespace ThreadingExplore.UnitTests.GameOfLife
{
    public class GameOfLifeGridTests
    {
        [Fact(DisplayName = "Should be able to create a grid.")]
        public void Test0010()
        {
            var grid = new GameOfLifeGrid();

            Assert.NotNull(grid);
        }

        [Fact(DisplayName = "GetCellStatus should return the status a cell given x at 0 and y at 0.")]
        public void Test0020()
        {
            var grid = new GameOfLifeGrid();

            var cellStatus = grid.GetCellStatus(0, 0);

            Assert.Equal(CellStatus.NotAlive, cellStatus);
        }

        [Fact(DisplayName = "GetCellStatus should return the status of a cell given an x and y within the max grid size.")]
        public void Test0030()
        {
            var grid = new GameOfLifeGrid();

            Assert.Equal(CellStatus.NotAlive, grid.GetCellStatus(0, 0));
            Assert.Equal(CellStatus.NotAlive, grid.GetCellStatus(1, 0));
            Assert.Equal(CellStatus.NotAlive, grid.GetCellStatus(2, 0));
            Assert.Equal(CellStatus.NotAlive, grid.GetCellStatus(0, 1));
            Assert.Equal(CellStatus.NotAlive, grid.GetCellStatus(1, 1));
            Assert.Equal(CellStatus.NotAlive, grid.GetCellStatus(2, 1));
            Assert.Equal(CellStatus.NotAlive, grid.GetCellStatus(0, 2));
            Assert.Equal(CellStatus.NotAlive, grid.GetCellStatus(1, 2));
            Assert.Equal(CellStatus.NotAlive, grid.GetCellStatus(2, 2));
        }

        [Fact(DisplayName = "SetCellStatus should change the status give an x and y within the max grid size.")]
        public void Test0040()
        {
            var grid = new GameOfLifeGrid();

            grid.SetCellStatus(0, 0, CellStatus.Alive);
            Assert.Equal(CellStatus.Alive, grid.GetCellStatus(0, 0));

            grid.SetCellStatus(0, 0, CellStatus.NotAlive);
            Assert.Equal(CellStatus.NotAlive, grid.GetCellStatus(0, 0));
        }

        [Fact(DisplayName = "SetCellStatus should not change the status of other cells.")]
        public void Test0050()
        {
            var grid = new GameOfLifeGrid();

            grid.SetCellStatus(0, 0, CellStatus.Alive);

            Assert.Equal(CellStatus.NotAlive, grid.GetCellStatus(1, 0));
            Assert.Equal(CellStatus.NotAlive, grid.GetCellStatus(2, 0));
        }

        [Theory(DisplayName = "SetCellStatus shoud be able to set the status of any cells within the max grid size.")]
        [InlineData(0, 0)]
        [InlineData(1, 0)]
        [InlineData(2, 0)]
        [InlineData(0, 1)]
        [InlineData(1, 1)]
        [InlineData(2, 1)]
        [InlineData(0, 2)]
        [InlineData(1, 2)]
        [InlineData(2, 2)]
        public void Test0060(
            int x, int y)
        {
            var grid = new GameOfLifeGrid();

            grid.SetCellStatus(x, y, CellStatus.Alive);
            Assert.Equal(CellStatus.Alive, grid.GetCellStatus(x, y));

            grid.SetCellStatus(x, y, CellStatus.NotAlive);
            Assert.Equal(CellStatus.NotAlive, grid.GetCellStatus(x, y));
        }

        [Fact(DisplayName = "SetGrid should set the entire grid from an array of strings.")]
        public void Test0070()
        {
            var testGrid = new string[3];

            testGrid[0] = "---";
            testGrid[1] = "---";
            testGrid[2] = "---";

            var grid = new GameOfLifeGrid();
            grid.SetGrid(testGrid);

            Assert.Equal(CellStatus.NotAlive, grid.GetCellStatus(0, 0));
            Assert.Equal(CellStatus.NotAlive, grid.GetCellStatus(1, 0));
            Assert.Equal(CellStatus.NotAlive, grid.GetCellStatus(2, 0));

            Assert.Equal(CellStatus.NotAlive, grid.GetCellStatus(0, 1));
            Assert.Equal(CellStatus.NotAlive, grid.GetCellStatus(1, 1));
            Assert.Equal(CellStatus.NotAlive, grid.GetCellStatus(2, 1));

            Assert.Equal(CellStatus.NotAlive, grid.GetCellStatus(0, 2));
            Assert.Equal(CellStatus.NotAlive, grid.GetCellStatus(1, 2));
            Assert.Equal(CellStatus.NotAlive, grid.GetCellStatus(2, 2));
        }

        [Fact(DisplayName = "SetGrid should setup a grid given a single alive cell.")]
        public void Test0080()
        {
            var testGrid = new string[3];

            testGrid[0] = "---";
            testGrid[1] = "-*-";
            testGrid[2] = "---";

            var grid = new GameOfLifeGrid();
            grid.SetGrid(testGrid);

            Assert.Equal(CellStatus.NotAlive, grid.GetCellStatus(0, 0));
            Assert.Equal(CellStatus.NotAlive, grid.GetCellStatus(1, 0));
            Assert.Equal(CellStatus.NotAlive, grid.GetCellStatus(2, 0));

            Assert.Equal(CellStatus.NotAlive, grid.GetCellStatus(0, 1));
            Assert.Equal(CellStatus.Alive, grid.GetCellStatus(1, 1));
            Assert.Equal(CellStatus.NotAlive, grid.GetCellStatus(2, 1));

            Assert.Equal(CellStatus.NotAlive, grid.GetCellStatus(0, 2));
            Assert.Equal(CellStatus.NotAlive, grid.GetCellStatus(1, 2));
            Assert.Equal(CellStatus.NotAlive, grid.GetCellStatus(2, 2));
        }

        [Fact(DisplayName = "SetGrid should setup a grid give multple living cells.")]
        public void Test0090()
        {
            var testGrid = new string[3];

            testGrid[0] = "***";
            testGrid[1] = "---";
            testGrid[2] = "-*-";

            var grid = new GameOfLifeGrid();
            grid.SetGrid(testGrid);

            Assert.Equal(CellStatus.Alive, grid.GetCellStatus(0, 0));
            Assert.Equal(CellStatus.Alive, grid.GetCellStatus(1, 0));
            Assert.Equal(CellStatus.Alive, grid.GetCellStatus(2, 0));

            Assert.Equal(CellStatus.NotAlive, grid.GetCellStatus(0, 1));
            Assert.Equal(CellStatus.NotAlive, grid.GetCellStatus(1, 1));
            Assert.Equal(CellStatus.NotAlive, grid.GetCellStatus(2, 1));

            Assert.Equal(CellStatus.NotAlive, grid.GetCellStatus(0, 2));
            Assert.Equal(CellStatus.Alive, grid.GetCellStatus(1, 2));
            Assert.Equal(CellStatus.NotAlive, grid.GetCellStatus(2, 2));
        }

        [Fact(DisplayName = "IsGridEqual should false when given string grid does not match the given grid.")]
        public void Test0100()
        {
            var grid = new GameOfLifeGrid();

            var stringGrid = new string[3];

            stringGrid[0] = "*--";
            stringGrid[1] = "---";
            stringGrid[2] = "---";

            Assert.False(grid.IsGridEqual(stringGrid));
        }

        [Fact(DisplayName = "IsGridEqual should return true when all cells are not alive.")]
        public void Test0110()
        {
            var grid = new GameOfLifeGrid();

            var stringGrid = new string[3];

            stringGrid[0] = "---";
            stringGrid[1] = "---";
            stringGrid[2] = "---";

            Assert.True(grid.IsGridEqual(stringGrid));
        }

        [Fact(DisplayName = "IsGridEqual should return true when the grid and string grid match on alive / dead cells.")]
        public void Test0120()
        {
            var grid = new GameOfLifeGrid();

            grid.SetCellStatus(0, 0, CellStatus.Alive);
            grid.SetCellStatus(1, 0, CellStatus.Alive);
            grid.SetCellStatus(2, 0, CellStatus.Alive);
            grid.SetCellStatus(1, 1, CellStatus.Alive);
            grid.SetCellStatus(1, 2, CellStatus.Alive);

            var stringGrid = new string[3];

            stringGrid[0] = "***";
            stringGrid[1] = "-*-";
            stringGrid[2] = "-*-";

            Assert.True(grid.IsGridEqual(stringGrid));
        }
    }
}