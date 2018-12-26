using FluentAssertions;
using Xunit;

namespace ThreadingExplore.UnitTests.PeakFinding2d
{
    public class PeakFinding2DTests
    {
        [Fact]
        public void ShouldFindPeakOfSingleItem()
        {
            int[,] grid = {{0}};

            var peakFinder = new PeakFinder();

            var peak = peakFinder.GetPeak(grid);

            peak.Value.Should().Be(0);
            peak.RowIndex.Should().Be(0);
            peak.ColumnIndex.Should().Be(0);
        }

        [Fact]
        public void ShouldFindPeakOfTwoItemsWithSameNumberInTwoColumns()
        {
            int[,] grid = { { 0, 0 } };

            var peakFinder = new PeakFinder();

            var peak = peakFinder.GetPeak(grid);

            peak.Value.Should().Be(0);
            peak.RowIndex.Should().Be(0);
            peak.ColumnIndex.Should().Be(0);
        }

        [Fact]
        public void ShouldFindPeakOfTwoItemsWithDifferentNumbers()
        {
            int[,] grid = { { 0, 1 } };

            var peakFinder = new PeakFinder();

            var peak = peakFinder.GetPeak(grid);

            peak.Value.Should().Be(0);
            peak.RowIndex.Should().Be(0);
            peak.ColumnIndex.Should().Be(1);
        }


    }

    public class PeakFinder
    {
        public FindResult GetPeak(
            int[,] grid)
        {
            if (grid.GetLength(0) == 1 && grid.GetLength(1) == 1)
                return new FindResult()
                {
                    Value = grid[0, 0]
                };

            if (grid[0, 1] > grid[0, 0])
                return new FindResult()
                {
                    Value = grid[0, 1]
                };


            return new FindResult()
            {
                Value = 0
            };
        }
    }

    public struct FindResult
    {
        public int Value { get; set; }
        public int RowIndex { get; set; }
        public int ColumnIndex { get; set; }
    }
}