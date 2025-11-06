namespace DSAlgorithms.Solutions.Core;

public static class TestStatusExtensions
{
    public static string ToDisplayString(this TestStatus status)
    {
        return status switch
        {
            TestStatus.PASS => "\u2713",
            TestStatus.FAIL => "X",
            TestStatus.SKIP => "[SKIP]",
            TestStatus.ERROR => "[ERROR]",
            _ => "[UNKNOWN]"
        };
    }

    public static void WriteStatusToConsole(this TestStatus status)
    {
        var color = status switch
        {
            TestStatus.PASS => ConsoleColor.Green,
            TestStatus.FAIL => ConsoleColor.Red,
            _ => ConsoleColor.White
        };

        Console.ForegroundColor = color;
        Console.Write(status.ToDisplayString());
        Console.ResetColor();
    }
}
