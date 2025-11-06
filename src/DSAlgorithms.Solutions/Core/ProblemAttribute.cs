namespace DSAlgorithms.Solutions.Core;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class ProblemAttribute : Attribute
{
    public string Source { get; set; } = string.Empty;
    public int Number { get; set; }
    public string Title { get; set; } = string.Empty;
    public Difficulty Difficulty { get; set; }
    public string[] Tags { get; set; } = Array.Empty<string>();
    public string Description { get; set; } = string.Empty;
    public string ProblemDate { get; set; } = string.Empty;

    public string FormattedNumber()
    {
        return Number == 0 ? string.Empty : $" #{Number}";
    }
}
