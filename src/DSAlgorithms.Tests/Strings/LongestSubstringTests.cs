using DSAlgorithms.Solutions.Strings;

namespace DSAlgorithms.Tests.Strings;

public class LongestSubstringTests
{
    private readonly LongestSubstring _solution;

    public LongestSubstringTests()
    {
        _solution = new LongestSubstring();
    }

    [Theory]
    [InlineData("abcabcbb", 3)]  // "abc"
    [InlineData("bbbbb", 1)]  // "b"
    [InlineData("pwwkew", 3)]  // "wke" or "kew"
    [InlineData("", 0)]  // Empty string
    [InlineData("abcdefg", 7)]  // Entire string is unique
    [InlineData("dvdf", 3)]  // "vdf"
    [InlineData("anviaj", 5)]  // "nviaj"
    public void Solve_StandardCases_ReturnsCorrectLength(string input, int expected)
    {
        // Act
        var result = _solution.Solve(input);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("a", 1)]
    [InlineData("z", 1)]
    [InlineData("1", 1)]
    [InlineData("!", 1)]
    public void Solve_SingleCharacter_ReturnsOne(string input, int expected)
    {
        // Act
        var result = _solution.Solve(input);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("aa", 1)]  // Two same chars
    [InlineData("aaa", 1)]  // Three same chars
    [InlineData("aaaaaaa", 1)]  // Many same chars
    [InlineData("111111", 1)]  // Same numbers
    public void Solve_AllSameCharacters_ReturnsOne(string input, int expected)
    {
        // Act
        var result = _solution.Solve(input);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("abc", 3)]
    [InlineData("abcdef", 6)]
    [InlineData("xyz", 3)]
    [InlineData("0123456789", 10)]
    public void Solve_AllUniqueCharacters_ReturnsFullLength(string input, int expected)
    {
        // Act
        var result = _solution.Solve(input);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("abba", 2)]  // "ab" or "ba"
    [InlineData("abcabc", 3)]  // "abc"
    [InlineData("aab", 2)]  // "ab"
    [InlineData("cdd", 2)]  // "cd"
    public void Solve_RepeatingPatterns_ReturnsCorrectLength(string input, int expected)
    {
        // Act
        var result = _solution.Solve(input);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Solve_EmptyString_ReturnsZero()
    {
        // Arrange
        string input = string.Empty;

        // Act
        var result = _solution.Solve(input);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void Solve_TwoCharactersDifferent_ReturnsTwo()
    {
        // Arrange
        string input = "ab";

        // Act
        var result = _solution.Solve(input);

        // Assert
        Assert.Equal(2, result);
    }

    [Fact]
    public void Solve_LongestAtStart_ReturnsCorrectLength()
    {
        // Arrange
        string input = "abcdeaaa";  // Longest is "abcde" (5 chars)

        // Act
        var result = _solution.Solve(input);

        // Assert
        Assert.Equal(5, result);
    }

    [Fact]
    public void Solve_LongestAtEnd_ReturnsCorrectLength()
    {
        // Arrange
        string input = "aaabcde";  // Longest is "abcde" (5 chars)

        // Act
        var result = _solution.Solve(input);

        // Assert
        Assert.Equal(5, result);
    }

    [Fact]
    public void Solve_LongestInMiddle_ReturnsCorrectLength()
    {
        // Arrange
        string input = "aabcdefaa";  // Longest is "abcdef" (6 chars)

        // Act
        var result = _solution.Solve(input);

        // Assert
        Assert.Equal(6, result);
    }

    [Fact]
    public void Solve_WithSpaces_HandlesCorrectly()
    {
        // Arrange
        string input = "a b c a";  // Longest is "a b", "b c", or "c a" (3 chars including spaces)

        // Act
        var result = _solution.Solve(input);

        // Assert
        Assert.Equal(3, result);
    }

    [Fact]
    public void Solve_WithNumbers_HandlesCorrectly()
    {
        // Arrange
        string input = "12312345";  // Longest is "12345" (5 chars)

        // Act
        var result = _solution.Solve(input);

        // Assert
        Assert.Equal(5, result);
    }

    [Fact]
    public void Solve_WithSpecialCharacters_HandlesCorrectly()
    {
        // Arrange
        string input = "!@#!@#$";  // Longest is "!@#$" (4 chars)

        // Act
        var result = _solution.Solve(input);

        // Assert
        Assert.Equal(4, result);
    }

    [Fact]
    public void Solve_MixedCase_TreatsAsDistinct()
    {
        // Arrange
        string input = "aAbBcC";  // All different (uppercase vs lowercase)

        // Act
        var result = _solution.Solve(input);

        // Assert
        Assert.Equal(6, result);
    }

    [Fact]
    public void Solve_MixedCaseWithRepeats_ReturnsCorrectLength()
    {
        // Arrange
        string input = "aAaA";  // Longest is "aA" (2 chars)

        // Act
        var result = _solution.Solve(input);

        // Assert
        Assert.Equal(2, result);
    }

    [Fact]
    public void Solve_AlphanumericMix_HandlesCorrectly()
    {
        // Arrange
        string input = "abc123abc";  // Longest is "abc123" or "123abc" (6 chars)

        // Act
        var result = _solution.Solve(input);

        // Assert
        Assert.Equal(6, result);
    }

    [Fact]
    public void Solve_LongStringWithRepeat_FindsLongestSubstring()
    {
        // Arrange
        string input = "abcdefghijklmnopqrstuvwxyza";  // Repeat 'a' at end, longest is 26

        // Act
        var result = _solution.Solve(input);

        // Assert
        Assert.Equal(26, result);
    }

    [Fact]
    public void Solve_ComplexPattern_ReturnsCorrectLength()
    {
        // Arrange
        string input = "tmmzuxt";  // Longest is "mzuxt" (5 chars)

        // Act
        var result = _solution.Solve(input);

        // Assert
        Assert.Equal(5, result);
    }

    [Fact]
    public void Solve_AlternatingRepeats_HandlesCorrectly()
    {
        // Arrange
        string input = "abcabcbb";  // From problem examples, longest is "abc" (3 chars)

        // Act
        var result = _solution.Solve(input);

        // Assert
        Assert.Equal(3, result);
    }

    [Fact]
    public void Solve_ImmediateRepeat_ReturnsCorrectLength()
    {
        // Arrange
        string input = "aabbcc";  // Longest is "ab", "bc" (2 chars)

        // Act
        var result = _solution.Solve(input);

        // Assert
        Assert.Equal(2, result);
    }
}
