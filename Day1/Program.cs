// Solution for https://adventofcode.com/2024/day/1

var input = File.ReadAllText("input.txt");

var firstList = new List<int>();
var secondList = new List<int>();

foreach (var item in input.Split("\r\n"))
{
    var splitted = item.Split(" ").Where(x => !string.IsNullOrEmpty(x)).ToList();
    firstList.Add(int.Parse(splitted[0]));
    secondList.Add(int.Parse(splitted[1]));
}

Console.WriteLine(SolvePart1(firstList, secondList));
Console.WriteLine(SolvePart2(firstList, secondList));

static int SolvePart2(List<int> firstList, List<int> secondList)
{
    return firstList.Aggregate(0, (total, current) =>
        total + (current * secondList.Where(x => x == current).Count())    
    );
}

static int SolvePart1(List<int> firstList, List<int> secondList)
{
    var firstListOrdered = firstList.OrderBy(x => x).ToList();
    var secondListOrdered = secondList.OrderBy(x => x).ToList();

    return Enumerable.Range(0, firstListOrdered.Count)
        .Aggregate(0, (total, i) =>
            total + Math.Abs(firstListOrdered[i] - secondListOrdered[i]));

    // Solution with for loop instead. Better readability?
    //List<int> distances = [];
    //for (int i = 0; i < firstListOrdered.Count; i++)
    //{
    //    var distance = Math.Abs(firstListOrdered[i] - secondListOrdered[i]);
    //    distances.Add(distance);
    //}

    //return distances.Sum();
}

