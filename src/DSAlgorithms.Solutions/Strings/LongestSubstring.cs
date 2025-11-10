using DSAlgorithms.Solutions.Core;

namespace DSAlgorithms.Solutions.Strings;

[Problem(
    Source = "LeetCode",
    Number = 3,
    Title = "Longest Substring Without Repeating Characters",
    Difficulty = Difficulty.Medium,
    Tags = new[] { "String", "Two Pointers", "Sliding Window" },
    Description = "Given a string `s`, find the length of the longest substring without repeating characters.",
    ProblemDate = "2025-11-10"
)]
public class LongestSubstring : IProblem
{
    /// <summary>
    /// Finds the length of the longest substring without repeating characters.
    /// </summary>
    public int Solve(string s)
    {
        // Expand right pointer when valid
        // Contract left pointer when invalid
        // Use hash set to track characters in window

        int left = 0;
        int maxLength = 0;
        var window = new HashSet<char>();

        for (int right = 0; right < s.Length; right++)
        {
            while (window.Contains(s[right]))
            {
                window.Remove(s[left]);
                left++;
            }

            window.Add(s[right]);

            maxLength = Math.Max(maxLength, right - left + 1);
        }

        return maxLength;
    }

    public void RunExamples()
    {
        var examples = new[]
        {
            ("abcabcbb", 3),
            ("bbbbb", 1),
            ("pwwkew", 3),
            ("", 0),
            ("abcdefg", 7)
        };

        Console.WriteLine("=== Longest Substring Examples ===\n");

        foreach (var (input, expected) in examples)
        {
            var original = input;
            var result = Solve(input);

            var status = result == expected ? TestStatus.PASS : TestStatus.FAIL;
            status.WriteStatusToConsole();
            Console.WriteLine($" Input: {original}");
            Console.WriteLine($"  Expected: {expected}, Got: {result}\n");
        }
    }
}
