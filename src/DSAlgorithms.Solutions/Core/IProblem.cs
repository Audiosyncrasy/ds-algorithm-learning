namespace DSAlgorithms.Solutions.Core;

/// <summary>
/// Marker interface for problem solution classes.
/// Implementing this interface allows for auto-discovery in the console runner.
/// </summary>
public interface IProblem
{
    /// <summary>
    /// Demonstrates the solution with example inputs/outputs.
    /// </summary>
    void RunExamples();
}
