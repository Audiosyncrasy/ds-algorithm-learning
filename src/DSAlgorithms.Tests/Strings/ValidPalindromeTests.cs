using DSAlgorithms.Solutions.Strings;

namespace DSAlgorithms.Tests.Strings;

public class ValidPalindromeTests
{
    private readonly ValidPalindrome _solution;

    public ValidPalindromeTests()
    {
        _solution = new ValidPalindrome();
    }

    [Theory]
    [InlineData("A man, a plan, a canal: Panama", true)]
    [InlineData("race a car", false)]
    [InlineData(" ", true)]
    [InlineData("", true)]
    [InlineData("0P", false)]
    [InlineData("a", true)]
    [InlineData("ab", false)]
    [InlineData("aba", true)]
    public void IsPalindrome_VariousInputs_ReturnsExpectedResult(string input, bool expected)
    {
        // Act
        var result = _solution.IsPalindrome(input);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void IsPalindrome_EmptyString_ReturnsTrue()
    {
        // Arrange
        var input = string.Empty;

        // Act
        var result = _solution.IsPalindrome(input);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsPalindrome_SingleCharacter_ReturnsTrue()
    {
        // Arrange
        var input = "a";

        // Act
        var result = _solution.IsPalindrome(input);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsPalindrome_OnlyNonAlphanumeric_ReturnsTrue()
    {
        // Arrange
        var input = ".,;!@#";

        // Act
        var result = _solution.IsPalindrome(input);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsPalindrome_MixedCaseValidPalindrome_ReturnsTrue()
    {
        // Arrange
        var input = "RaceCar";

        // Act
        var result = _solution.IsPalindrome(input);

        // Assert
        Assert.True(result);
    }
}
