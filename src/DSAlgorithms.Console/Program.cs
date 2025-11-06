using DSAlgorithms.Console;
using DSAlgorithms.Solutions.Core;

Console.WriteLine("╔════════════════════════════════════════════════════════╗");
Console.WriteLine("║   Data Structures & Algorithms Solution Runner         ║");
Console.WriteLine("╚════════════════════════════════════════════════════════╝\n");

var problems = ProblemDiscovery.DiscoverAllProblems();
var problemsByCategory = ProblemDiscovery.GroupByCategory(problems);

Console.WriteLine($"Found {problems.Count} problem(s) across {problemsByCategory.Count} category(ies).\n");

while (true)
{
    DisplayMainMenu(problemsByCategory);

    var choice = Console.ReadLine();

    if (choice?.ToLower() == "q")
        break;

    if (int.TryParse(choice, out int selectedIndex) && selectedIndex > 0 && selectedIndex <= problems.Count)
    {
        var selectedProblem = problems[selectedIndex - 1];
        RunProblem(selectedProblem);
    }
    else
    {
        Console.WriteLine("\nInvalid selection. Please try again.\n");
    }
}

Console.WriteLine("\nGoodbye!");

static void DisplayMainMenu(Dictionary<string, List<ProblemInfo>> problemsByCategory)
{
    Console.WriteLine("╔════════════════════════════════════════════════════════╗");
    Console.WriteLine("║                    PROBLEM MENU                        ║");
    Console.WriteLine("╚════════════════════════════════════════════════════════╝\n");

    int index = 1;
    foreach (var (category, categoryProblems) in problemsByCategory)
    {
        Console.WriteLine($"  [{category}]");
        foreach (var problem in categoryProblems)
        {
            var difficulty = problem.Metadata.Difficulty switch
            {
                Difficulty.Easy => " Easy ",
                Difficulty.Medium => "Medium",
                Difficulty.Hard => " Hard ",
                _ => "      "
            };

            ConsoleColor difficultyColor = problem.Metadata.Difficulty switch
            {
                Difficulty.Easy => ConsoleColor.Green,
                Difficulty.Medium => ConsoleColor.Yellow,
                Difficulty.Hard => ConsoleColor.Red,
                _ => ConsoleColor.Black
            };

            Console.Write($"    {index}. {problem.DisplayName} (");
                Console.ForegroundColor = difficultyColor;
                Console.Write($"{difficulty}");
                Console.ResetColor();
            Console.WriteLine($")");
            index++;
        }
        Console.WriteLine();
    }

    Console.WriteLine("  Enter the problem number to run, or 'Q' to quit: ");
    Console.Write("  > ");
}

static void RunProblem(ProblemInfo problemInfo)
{
    Console.Clear();
    problemInfo.PrintDetails();

    try
    {
        var instance = Activator.CreateInstance(problemInfo.Type) as IProblem;
        instance?.RunExamples();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error running problem: {ex.Message}");
    }

    Console.WriteLine("\nPress any key to return to menu...");
    Console.ReadKey();
    Console.Clear();
}
