using DSAlgorithms.Solutions.Core;

namespace DSAlgorithms.Console;

public class ProblemInfo
{
    public Type Type { get; set; } = null!;
    public ProblemAttribute Metadata { get; set; } = null!;
    public string Category { get; set; } = string.Empty;

    public string DisplayName => $"[{Metadata.Source}{Metadata.FormattedNumber()}] {Metadata.Title}";

    public void PrintDetails()
    {
        System.Console.WriteLine($"\n{'=',-60}");
        System.Console.WriteLine($"Title:       {Metadata.Title}");
        System.Console.WriteLine($"Source:      {Metadata.Source}{Metadata.FormattedNumber()}");
        System.Console.WriteLine($"Difficulty:  {Metadata.Difficulty}");
        System.Console.WriteLine($"Tags:        {string.Join(", ", Metadata.Tags)}");
        System.Console.WriteLine($"Description: {Metadata.Description}");
        System.Console.WriteLine($"{'=',-60}\n");
    }
}
