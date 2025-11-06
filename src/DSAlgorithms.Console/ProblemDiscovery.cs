using System.Reflection;
using DSAlgorithms.Solutions.Core;

namespace DSAlgorithms.Console;

public static class ProblemDiscovery
{
    public static List<ProblemInfo> DiscoverAllProblems()
    {
        var problems = new List<ProblemInfo>();
        var solutionsAssembly = Assembly.Load("DSAlgorithms.Solutions");

        var problemTypes = solutionsAssembly.GetTypes()
            .Where(t => typeof(IProblem).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);

        foreach (var type in problemTypes)
        {
            var attribute = type.GetCustomAttribute<ProblemAttribute>();
            if (attribute != null)
            {
                problems.Add(new ProblemInfo
                {
                    Type = type,
                    Metadata = attribute,
                    Category = type.Namespace?.Split('.').LastOrDefault() ?? "Uncategorized"
                });
            }
        }

        return problems.OrderBy(p => p.Category)
                      .ThenBy(p => p.Metadata.Difficulty)
                      .ThenBy(p => p.Metadata.Number)
                      .ToList();
    }

    public static Dictionary<string, List<ProblemInfo>> GroupByCategory(List<ProblemInfo> problems)
    {
        return problems.GroupBy(p => p.Category)
                      .ToDictionary(g => g.Key, g => g.ToList());
    }
}
