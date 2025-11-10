using DSAlgorithms.Solutions.Arrays;

namespace DSAlgorithms.Tests.Arrays;

public class MaximumAverageSubarrayTests
{
    private readonly MaximumAverageSubarray _solution;
    private const double Tolerance = 0.00001;

    public MaximumAverageSubarrayTests()
    {
        _solution = new MaximumAverageSubarray();
    }

    [Theory]
    [InlineData(new[] { 1, 12, -5, -6, 50, 3 }, 4, 12.75)]  // Example from problem
    [InlineData(new[] { 5, 5, 5, 5, 5 }, 3, 5.0)]  // All same values
    [InlineData(new[] { 1, 2, 3, 4, 5 }, 3, 4.0)]  // Max at end: [3,4,5] = 12/3 = 4
    [InlineData(new[] { 5, 4, 3, 2, 1 }, 3, 4.0)]  // Max at start: [5,4,3] = 12/3 = 4
    [InlineData(new[] { 1, 3, 5, 3, 1 }, 3, 3.666667)]  // Max in middle: [1,3,5] = 9/3 = 3
    [InlineData(new[] { -1, -2, -3, -4 }, 2, -1.5)]  // All negative: [-1,-2] = -3/2 = -1.5
    public void Solve_StandardCases_ReturnsCorrectMaxAverage(int[] nums, int k, double expected)
    {
        // Act
        var result = _solution.Solve(nums, k);

        // Assert
        Assert.Equal(expected, result, Tolerance);
    }

    [Theory]
    [InlineData(new[] { 5 }, 1, 5.0)]
    [InlineData(new[] { -3 }, 1, -3.0)]
    [InlineData(new[] { 0 }, 1, 0.0)]
    [InlineData(new[] { 100 }, 1, 100.0)]
    public void Solve_SingleElementArray_ReturnsElementValue(int[] nums, int k, double expected)
    {
        // Act
        var result = _solution.Solve(nums, k);

        // Assert
        Assert.Equal(expected, result, Tolerance);
    }

    [Theory]
    [InlineData(new[] { 3, 7 }, 2, 5.0)]
    [InlineData(new[] { -2, 8 }, 2, 3.0)]
    [InlineData(new[] { 0, 0 }, 2, 0.0)]
    public void Solve_KEqualsArrayLength_ReturnsOverallAverage(int[] nums, int k, double expected)
    {
        // Act
        var result = _solution.Solve(nums, k);

        // Assert
        Assert.Equal(expected, result, Tolerance);
    }

    [Theory]
    [InlineData(new[] { 1, 2, 3, 4, 5, 6 }, 1, 6.0)]  // Max is last element
    [InlineData(new[] { 10, 2, 3, 4, 5 }, 1, 10.0)]  // Max is first element
    [InlineData(new[] { 1, 2, 50, 3, 4 }, 1, 50.0)]  // Max is in middle
    public void Solve_WindowSizeOne_ReturnsMaxElement(int[] nums, int k, double expected)
    {
        // Act
        var result = _solution.Solve(nums, k);

        // Assert
        Assert.Equal(expected, result, Tolerance);
    }

    [Fact]
    public void Solve_MixedPositiveAndNegative_ReturnsCorrectMaxAverage()
    {
        // Arrange
        int[] nums = new[] { -5, 10, -3, 7, -2 };
        int k = 2;
        // Windows: [-5,10]=5/2=2.5, [10,-3]=7/2=3.5*, [-3,7]=4/2=2, [7,-2]=5/2=2.5

        // Act
        var result = _solution.Solve(nums, k);

        // Assert
        Assert.Equal(3.5, result, Tolerance);
    }

    [Fact]
    public void Solve_AllZeros_ReturnsZero()
    {
        // Arrange
        int[] nums = new[] { 0, 0, 0, 0, 0 };
        int k = 3;

        // Act
        var result = _solution.Solve(nums, k);

        // Assert
        Assert.Equal(0.0, result, Tolerance);
    }

    [Fact]
    public void Solve_LargeNumbers_HandlesCorrectly()
    {
        // Arrange
        int[] nums = new[] { 1000, 2000, 3000, 4000 };
        int k = 2;
        // Windows: [1000,2000]=1500, [2000,3000]=2500, [3000,4000]=3500*

        // Act
        var result = _solution.Solve(nums, k);

        // Assert
        Assert.Equal(3500.0, result, Tolerance);
    }

    [Fact]
    public void Solve_WindowAtStart_IdentifiesCorrectly()
    {
        // Arrange
        int[] nums = new[] { 100, 50, 25, 1, 1, 1 };
        int k = 3;
        // Windows: [100,50,25]=175/3=58.333*, [50,25,1]=25.333, [25,1,1]=9, [1,1,1]=1

        // Act
        var result = _solution.Solve(nums, k);

        // Assert
        Assert.Equal(58.333333, result, Tolerance);
    }

    [Fact]
    public void Solve_WindowAtEnd_IdentifiesCorrectly()
    {
        // Arrange
        int[] nums = new[] { 1, 1, 1, 25, 50, 100 };
        int k = 3;
        // Windows: [1,1,1]=1, [1,1,25]=9, [1,25,50]=25.333, [25,50,100]=175/3=58.333*

        // Act
        var result = _solution.Solve(nums, k);

        // Assert
        Assert.Equal(58.333333, result, Tolerance);
    }

    [Fact]
    public void Solve_AlternatingValues_FindsMaxAverage()
    {
        // Arrange
        int[] nums = new[] { 1, -1, 1, -1, 1, -1 };
        int k = 2;
        // All windows sum to 0, average = 0

        // Act
        var result = _solution.Solve(nums, k);

        // Assert
        Assert.Equal(0.0, result, Tolerance);
    }

    [Fact]
    public void Solve_DecimalResult_ReturnsCorrectPrecision()
    {
        // Arrange
        int[] nums = new[] { 1, 2, 3 };
        int k = 3;
        // Window [1,2,3] = 6/3 = 2.0

        // Act
        var result = _solution.Solve(nums, k);

        // Assert
        Assert.Equal(2.0, result, Tolerance);
    }

    [Fact]
    public void Solve_LongArray_ProcessesEfficiently()
    {
        // Arrange
        int[] nums = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
        int k = 4;
        // Last window [9,10,11,12] = 42/4 = 10.5

        // Act
        var result = _solution.Solve(nums, k);

        // Assert
        Assert.Equal(10.5, result, Tolerance);
    }

    [Fact]
    public void Solve_NegativeAndPositiveMix_HandlesCorrectly()
    {
        // Arrange
        int[] nums = new[] { -10, 20, -30, 40, -50, 60 };
        int k = 3;
        // Windows: [-10,20,-30]=-20/3, [20,-30,40]=30/3=10, [-30,40,-50]=-40/3, [40,-50,60]=50/3=16.666*

        // Act
        var result = _solution.Solve(nums, k);

        // Assert
        Assert.Equal(16.666667, result, Tolerance);
    }
}
