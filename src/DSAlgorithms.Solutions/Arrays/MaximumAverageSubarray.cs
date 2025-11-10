using DSAlgorithms.Solutions.Core;
using System.ComponentModel;
using System.Globalization;
using System.Xml.Linq;

namespace DSAlgorithms.Solutions.Arrays;

[Problem(
    Source = "LeetCode",
    Number = 643,
    Title = "Maximum Average Subarray I",
    Difficulty = Difficulty.Easy,
    Tags = new[] { "Array", "Two Pointers" },
    Description = "Given an array of integers `nums` and an integer `k`, find the contiguous subarray of length `k` " +
                  "that has the maximum average value. Return the maximum average.",
    ProblemDate = "2025-11-06"
)]
public class MaximumAverageSubarray : IProblem
{
    /// <summary>
    /// Returns the maximum average value from a subset of an array (SlidingWindow) of length `k`.
    /// Time Complexity: O(n)
    /// Space Complexity: O(1)
    /// </summary>
    public double Solve(int[] nums, int k)
    {
        var windowSum = 0.0;
        
        for (var i = 0; i < k; i++)
        {
            windowSum += nums[i];
        }

        var maxSum = windowSum;

        for (var i = k; i < nums.Length; i++)
        {
            var first = nums[i - k];
            var last = nums[i];

            windowSum = windowSum - first + last;

            if(windowSum > maxSum)
            {
                maxSum = windowSum;
            }
        }
        
        return maxSum / k;
    }

    public void RunExamples()
    {
        var examples = new[]
        {
            (nums: new[] {1,12,-5,-6,50,3}, k: 4, expected: 12.75)
        };

        Console.WriteLine("=== Sliding Window Examples ===\n");

        foreach (var (nums, k, expected) in examples)
        {
            var result = Solve(nums, k);
            var status = result == expected ? TestStatus.PASS : TestStatus.FAIL;
            status.WriteStatusToConsole();
            Console.WriteLine($" Input: nums=[{string.Join(',', nums)}], k={k}");
            Console.WriteLine($"  Expected: {expected}, Got: {result}\n");
        }
    }
}
