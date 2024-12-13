// Solution for https://adventofcode.com/2024/day/2

var input = File.ReadAllText("input.txt");

var reports = new List<List<int>>();

foreach (var report in input.Split("\r\n"))
{
    var splitted = report.Split(" ").Where(x => !string.IsNullOrEmpty(x)).ToList();
    var levels = splitted.Select(x => int.Parse(x)).ToList();
    reports.Add(levels);
}

Console.WriteLine(SolvePart1(reports));
Console.WriteLine(SolvePart2(reports));

static int SolvePart1(List<List<int>> reports) =>
    reports.Where(ReportIsSafe).Count();

static int SolvePart2(List<List<int>> reports) =>
    reports.Where(report => ReportIsSafe(report) || ProblemDampener(report)).Count();

static bool ReportIsSafe(List<int> levels)
{
    var safe = true;
    var decreasing = levels[0] - levels[1] > 0;
    for (int i = 0; i < levels.Count - 1; i++)
    {
        var difference = levels[i] - levels[i + 1];
        safe = Math.Abs(difference) > 0 && Math.Abs(difference) <= 3;
        safe = safe && (decreasing == difference > 0);
        if (!safe) break;
    }

    return safe;
}

static bool ProblemDampener(List<int> levels)
{
    var problemDampened = false;
    for (int i = 0; i < levels.Count; i++)
    {
        List<int> newList = [.. levels];
        newList.RemoveAt(i);
        problemDampened = ReportIsSafe(newList);
        if (problemDampened) break;
    }
    return problemDampened;
}