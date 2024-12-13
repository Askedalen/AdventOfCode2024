// Solution for https://adventofcode.com/2024/day/3

using System.Text.RegularExpressions;

var input = File.ReadAllText("input.txt");

Console.WriteLine(SolvePart1(input));
Console.WriteLine(SolvePart2(input));

static int SolvePart1(string input)
{
    var pattern = @"mul\(\d{1,3},\d{1,3}\)";
    var matches = Regex.Matches(input, pattern);

    return PerformMultiplyOperations(matches).Sum();
}

static int SolvePart2(string input)
{
    var inputWithoutDonts = string.Join("",
        input.Split("do()").SelectMany(x => x.Split("don't()")[0]));

    var pattern = @"mul\(\d{1,3},\d{1,3}\)";
    var matches = Regex.Matches(inputWithoutDonts, pattern);

    return PerformMultiplyOperations(matches).Sum();

}

static List<int> PerformMultiplyOperations(MatchCollection matches) =>
    matches.Select(match => match.Value
        .Trim('m', 'u', 'l', '(', ')')
        .Split(",")
        .Aggregate(1, (a, b) => a * int.Parse(b)))
        .ToList();
