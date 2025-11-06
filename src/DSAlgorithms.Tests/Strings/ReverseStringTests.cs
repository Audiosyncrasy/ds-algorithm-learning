using DSAlgorithms.Solutions.Strings;

namespace DSAlgorithms.Tests.Strings;

public class ReverseStringTests
{
    private readonly ReverseString _solution;

    public ReverseStringTests()
    {
        _solution = new ReverseString();
    }

    [Theory]
    [InlineData(new[] { 'h', 'e', 'l', 'l', 'o' }, new[] { 'o', 'l', 'l', 'e', 'h' })]
    [InlineData(new[] { 'H', 'a', 'n', 'n', 'a', 'h' }, new[] { 'h', 'a', 'n', 'n', 'a', 'H' })]
    [InlineData(new[] { 'A', 'b', 'C', 'd', 'E' }, new[] { 'E', 'd', 'C', 'b', 'A' })]
    [InlineData(new[] { 'a', '1', 'b', '2', 'c', '3' }, new[] { '3', 'c', '2', 'b', '1', 'a' })]
    [InlineData(new[] { 'x', 'y', 'z' }, new[] { 'z', 'y', 'x' })]
    [InlineData(new[] { 'a', ' ', 'b', ' ', 'c' }, new[] { 'c', ' ', 'b', ' ', 'a' })]
    public void ReverseString_VariousInputs_ReversesCorrectly(char[] input, char[] expected)
    {
        // Act
        _solution.Solve(input);

        // Assert
        Assert.Equal(expected, input);
    }

    [Theory]
    [InlineData(new[] { 'A' })]
    [InlineData(new[] { 'a', 'b' })]
    [InlineData(new[] { 'x', 'x' })]
    public void ReverseString_SmallArrays_HandlesCorrectly(char[] input)
    {
        // Arrange
        char[] expected = new char[input.Length];
        for (int i = 0; i < input.Length; i++)
        {
            expected[i] = input[input.Length - 1 - i];
        }

        // Act
        _solution.Solve(input);

        // Assert
        Assert.Equal(expected, input);
    }

    [Theory]
    [InlineData(new[] { 'r', 'a', 'c', 'e', 'c', 'a', 'r' })]
    [InlineData(new[] { 'a', 'b', 'a' })]
    [InlineData(new[] { 'a', 'a', 'a', 'a', 'a' })]
    public void ReverseString_Palindromes_RemainsUnchanged(char[] input)
    {
        // Arrange
        char[] expected = (char[])input.Clone();

        // Act
        _solution.Solve(input);

        // Assert
        Assert.Equal(expected, input);
    }

    [Theory]
    [InlineData(new[] { '1', '2', '3', '4', '5' }, new[] { '5', '4', '3', '2', '1' })]
    [InlineData(new[] { '!', '@', '#', '$', '%' }, new[] { '%', '$', '#', '@', '!' })]
    [InlineData(new[] { '0', '9', '8' }, new[] { '8', '9', '0' })]
    public void ReverseString_SpecialCharactersAndNumbers_ReversesCorrectly(char[] input, char[] expected)
    {
        // Act
        _solution.Solve(input);

        // Assert
        Assert.Equal(expected, input);
    }

    [Fact]
    public void ReverseString_LongString_ReversesCorrectly()
    {
        // Arrange
        char[] input = "abcdefghijklmnop".ToCharArray();
        char[] expected = "ponmlkjihgfedcba".ToCharArray();

        // Act
        _solution.Solve(input);

        // Assert
        Assert.Equal(expected, input);
    }

    [Fact]
    public void ReverseString_UnicodeCharacters_ReversesCorrectly()
    {
        // Arrange - Using actual unicode characters (accented letters)
        char[] input = new[] { 'á', 'é', 'í', 'ó', 'ú' };
        char[] expected = new[] { 'ú', 'ó', 'í', 'é', 'á' };

        // Act
        _solution.Solve(input);

        // Assert
        Assert.Equal(expected, input);
    }
}
