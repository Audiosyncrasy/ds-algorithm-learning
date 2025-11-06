using DSAlgorithms.Solutions.Core;

namespace DSAlgorithms.Solutions.Strings;

[Problem(
    Source = "Claude",
    Title = "ReverseString",
    Difficulty = Difficulty.Easy,
    Tags = new[] { "String", "Two Pointers" },
    Description = "Reverses a string by modifying the char array in place.",
    ProblemDate = "2025-11-05"
)]
public class ReverseString : IProblem
{
    /// <summary>
    /// Reverses a string in place.
    /// </summary>
    public void Solve(char[] s)
    {
        if (s.Length == 0 || s.Length == 1) return;

        int left = 0, right = s.Length - 1;

        while (left < right)
        {
            char leftVal = s[left];
            char rightVal = s[right];

            s[left] = rightVal;
            s[right] = leftVal;

            left++;
            right--;
        }
    }

    public void RunExamples()
    {
        var examples = new[]
        {
            (['h','e','l','l','o'], "olleh"),
            (['H','a','n','n','a','h'], "hannaH"),
            (new char[] {'A'}, "A")
        };

        Console.WriteLine("=== Reverse String Examples ===\n");

        foreach (var (input, expected) in examples)
        {
            var original = string.Join("", input);
            Solve(input);
            var result = string.Join("", input);

            var status = result == expected ? "✓" : "✗";
            Console.WriteLine($"{status} Input: {original}");
            Console.WriteLine($"  Expected: {expected}, Got: {result}\n");
        }
    }
}
