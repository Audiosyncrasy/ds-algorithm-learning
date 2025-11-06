using DSAlgorithms.Solutions.Core;

namespace DSAlgorithms.Solutions.Strings;

[Problem(
    Source = "LeetCode",
    Number = 125,
    Title = "Valid Palindrome",
    Difficulty = Difficulty.Easy,
    Tags = new[] { "String", "Two Pointers" },
    Description = "A phrase is a palindrome if, after converting all uppercase letters into lowercase letters " +
                  "and removing all non-alphanumeric characters, it reads the same forward and backward.",
    ProblemDate = "2025-11-05"
)]
public class ValidPalindrome : IProblem
{
    /// <summary>
    /// Determines if a string is a valid palindrome.
    /// Time Complexity: O(n)
    /// Space Complexity: O(1)
    /// </summary>
    public bool IsPalindrome(string s)
    {
        if (string.IsNullOrEmpty(s))
            return true;

        int left = 0;
        int right = s.Length - 1;

        while (left < right)
        {
            // Skip non-alphanumeric characters from left
            while (left < right && !char.IsLetterOrDigit(s[left]))
                left++;

            // Skip non-alphanumeric characters from right
            while (left < right && !char.IsLetterOrDigit(s[right]))
                right--;

            // Compare characters (case-insensitive)
            if (char.ToLower(s[left]) != char.ToLower(s[right]))
                return false;

            left++;
            right--;
        }

        return true;
    }

    public void RunExamples()
    {
        var examples = new[]
        {
            ("A man, a plan, a canal: Panama", true),
            ("race a car", false),
            (" ", true),
            ("", true),
            ("0P", false)
        };

        Console.WriteLine("=== Valid Palindrome Examples ===\n");

        foreach (var (input, expected) in examples)
        {
            var result = IsPalindrome(input);
            var status = result == expected ? "✓" : "✗";
            Console.WriteLine($"{status} Input: \"{input}\"");
            Console.WriteLine($"  Expected: {expected}, Got: {result}\n");
        }
    }
}
