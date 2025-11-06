using DSAlgorithms.Solutions.Core;
using System.ComponentModel;
using System.Xml.Linq;

namespace DSAlgorithms.Solutions.Arrays;

[Problem(
    Source = "Claude",
    Title = "Max Area",
    Difficulty = Difficulty.Easy,
    Tags = new[] { "Array", "Two Pointers" },
    Description = "You are given an array of integers height where each element represents the height of a vertical line. " +
                  "Find two lines that together with the x - axis form a container that holds the most water.",
    ProblemDate = "2025-11-05"
)]
public class MaxArea : IProblem
{
    /// <summary>
    /// Using an array of height values and the index position of the height value in the array, determine the "container" that will hold the most "water."
    /// Time Complexity:
    /// Space Complexity:
    /// </summary>
    public int Solve(int[] height)
    {
        if (height.Length == 0 || height.Length == 1) return 0;

        int left = 0, right = height.Length - 1;

        int maxArea = 0;

        while (left < right)
        {
            int currentWidth = right - left;
            int currentHeight = Math.Min(height[left], height[right]);
            int currentArea = currentWidth * currentHeight;

            maxArea = Math.Max(currentArea, maxArea);

            if (height[left] > height[right])
            {
                right--;
            }
            else
            {
                left++;
            }
        }

        return maxArea;
    }

    public void RunExamples()
    {
        var examples = new[]
        {
            ([1,8,6,2,5,4,8,3,7], 49),
            (new int[] {1,1}, 1)
        };

        Console.WriteLine("=== Max Area Examples ===\n");

        foreach (var (input, expected) in examples)
        {
            var result = Solve(input);
            var status = result == expected ? TestStatus.PASS : TestStatus.FAIL;
            status.WriteStatusToConsole();
            Console.WriteLine($" Input: \"{input}\"");
            Console.WriteLine($"  Expected: {expected}, Got: {result}\n");
        }
    }
}
