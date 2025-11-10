using DSAlgorithms.Solutions.Arrays;

namespace DSAlgorithms.Tests.Arrays;

public class ContainerWithMostWaterTests
{
    private readonly ContainerWithMostWater _solution;

    public ContainerWithMostWaterTests()
    {
        _solution = new ContainerWithMostWater();
    }

    [Theory]
    [InlineData(new[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 }, 49)]  // Classic example: positions 1 and 8
    [InlineData(new[] { 1, 1 }, 1)]  // Two equal heights
    [InlineData(new[] { 4, 3, 2, 1, 4 }, 16)]  // Max at ends
    [InlineData(new[] { 1, 2, 1 }, 2)]  // Max at ends with lower heights
    [InlineData(new[] { 2, 3, 4, 5, 18, 17, 6 }, 17)]  // Large height in middle
    public void Solve_StandardCases_ReturnsCorrectMaxArea(int[] height, int expected)
    {
        // Act
        var result = _solution.Solve(height);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(new int[] { })]  // Empty array
    [InlineData(new[] { 5 })]  // Single element
    public void Solve_InsufficientElements_ReturnsZero(int[] height)
    {
        // Act
        var result = _solution.Solve(height);

        // Assert
        Assert.Equal(0, result);
    }

    [Theory]
    [InlineData(new[] { 5, 5, 5, 5 }, 15)]  // All same height
    [InlineData(new[] { 3, 3, 3 }, 6)]  // All same height (odd count)
    [InlineData(new[] { 7, 7 }, 7)]  // Two same heights
    public void Solve_UniformHeights_ReturnsCorrectArea(int[] height, int expected)
    {
        // Act
        var result = _solution.Solve(height);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(new[] { 1, 2, 3, 4, 5 }, 6)]  // Ascending heights
    [InlineData(new[] { 5, 4, 3, 2, 1 }, 6)]  // Descending heights
    public void Solve_MonotonicHeights_ReturnsCorrectArea(int[] height, int expected)
    {
        // Act
        var result = _solution.Solve(height);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Solve_TwoElements_ReturnsMinHeight()
    {
        // Arrange
        int[] height = new[] { 3, 7 };

        // Act
        var result = _solution.Solve(height);

        // Assert - width is 1, height is min(3,7) = 3
        Assert.Equal(3, result);
    }

    [Fact]
    public void Solve_TallestAtEnds_ReturnsMaxArea()
    {
        // Arrange
        int[] height = new[] { 10, 1, 1, 1, 1, 1, 10 };

        // Act
        var result = _solution.Solve(height);

        // Assert - width is 6, height is min(10,10) = 10
        Assert.Equal(60, result);
    }

    [Fact]
    public void Solve_OneTallLineAndManyShort_ReturnsOptimalArea()
    {
        // Arrange
        int[] height = new[] { 1, 100, 1, 1, 1, 1, 1 };

        // Act
        var result = _solution.Solve(height);

        // Assert - Best is positions 0 to 6: width=6, height=min(1,1)=1
        Assert.Equal(6, result);
    }

    [Fact]
    public void Solve_ZeroHeights_ReturnsZero()
    {
        // Arrange
        int[] height = new[] { 0, 0, 0 };

        // Act
        var result = _solution.Solve(height);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void Solve_MixedWithZeros_ReturnsCorrectArea()
    {
        // Arrange
        int[] height = new[] { 0, 5, 0, 5, 0 };

        // Act
        var result = _solution.Solve(height);

        // Assert - positions 1 and 3: width=2, height=5
        Assert.Equal(10, result);
    }

    [Fact]
    public void Solve_LargeArray_HandlesCorrectly()
    {
        // Arrange
        int[] height = new[] { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25 };

        // Act
        var result = _solution.Solve(height);

        // Assert - positions 0 and 12: width=12, height=1 = 12
        // But positions 6 and 12: width=6, height=13 = 78
        // Actually best is positions 0 and 12: width=12, height=min(1,25)=1 = 12
        // Let me recalculate: positions 6 and 12: width=6, height=min(13,25)=13 = 78
        Assert.Equal(78, result);
    }

    [Fact]
    public void Solve_ThreeElements_ReturnsMaxOfTwoPossiblePairs()
    {
        // Arrange
        int[] height = new[] { 1, 5, 2 };

        // Act
        var result = _solution.Solve(height);

        // Assert - positions 0 and 2: width=2, height=min(1,2)=1 = 2
        // positions 0 and 1: width=1, height=min(1,5)=1 = 1
        // positions 1 and 2: width=1, height=min(5,2)=2 = 2
        // Max from two-pointer algorithm should be 2
        Assert.Equal(2, result);
    }

    [Fact]
    public void Solve_PeakInMiddle_FindsOptimalArea()
    {
        // Arrange
        int[] height = new[] { 1, 2, 4, 3 };

        // Act
        var result = _solution.Solve(height);

        // Assert - positions 0 and 3: width=3, height=min(1,3)=1 = 3
        // positions 1 and 3: width=2, height=min(2,3)=2 = 4
        Assert.Equal(4, result);
    }
}
