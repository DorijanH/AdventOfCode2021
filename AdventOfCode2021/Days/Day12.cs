namespace AdventOfCode2021.Days;

/// <summary>
/// Class representing the advent day 12.
/// </summary>
public class Day12 : AdventDay
{
    private readonly Dictionary<string, List<string>> adjacentDictionary = new();
    private HashSet<string> visited;

    private const string StartNode = "start";
    private const string EndNode = "end";

    /// <summary>
    /// Initializes the class representing the advent day 12.
    /// </summary>
    /// <param name="isExample">Should example input be used.</param>
    public Day12(bool isExample = false) : base(12, isExample)
    {
        this.FillTheAdjacentDictionary();
    }

    /// <summary>
    /// Solves the first part of the advent day puzzle.
    /// </summary>
    /// <returns>Puzzle result.</returns>
    public override string SolveFirstPart()
    {
        this.visited = new HashSet<string>();

        var pathsCount = this.DepthFirstSearchCount(StartNode);

        Console.WriteLine($"There are: {pathsCount} paths");

        return $"{pathsCount}";
    }

    /// <summary>
    /// Solves the second part of the advent day puzzle.
    /// </summary>
    /// <returns>Puzzle result.</returns>
    public override string SolveSecondPart()
    {
        return string.Empty;
    }

    /// <summary>
    /// Counts the distinct paths through the graph using the modified DFS algorithm where the lower case
    /// nodes can be traversed through once at most.
    /// </summary>
    /// <param name="currentNode">Current node while traversing.</param>
    /// <returns>Count of distinct paths from the start to the end node.</returns>
    private int DepthFirstSearchCount(string currentNode)
    {
        if (currentNode == EndNode) return 1;

        var pathCount = 0;

        if (currentNode == currentNode.ToLower()) this.visited.Add(currentNode);

        foreach (var nextNode in this.adjacentDictionary[currentNode])
        {
            if (!this.HaveVisited(nextNode))
            {
                pathCount += this.DepthFirstSearchCount(nextNode);

                if (nextNode == nextNode.ToLower()) this.visited.Remove(nextNode);
            }
        }

        return pathCount;
    }

    /// <summary>
    /// Checks if the node has already been visited.
    /// </summary>
    /// <param name="node">Node to check.</param>
    /// <returns>Boolean representing has the node already been visited.</returns>
    private bool HaveVisited(string node)
    {
        return this.visited.Contains(node);
    }

    /// <summary>
    /// Gets the initial adjacent nodes dictionary from the puzzle input.
    /// </summary>
    /// <returns>Initial adjacent nodes dictionary.</returns>
    private void FillTheAdjacentDictionary()
    {
        var inputs = this.InputContents
            .Split('\n', StringSplitOptions.TrimEntries);

        foreach (var inputLine in inputs)
        {
            var nodesParsed = inputLine.Split('-', StringSplitOptions.TrimEntries);
            var fromNode = nodesParsed[0];
            var toNode = nodesParsed[1];

            if (!this.adjacentDictionary.ContainsKey(fromNode))
                this.adjacentDictionary.Add(fromNode, new List<string>());

            if (!this.adjacentDictionary.ContainsKey(toNode))
                this.adjacentDictionary.Add(toNode, new List<string>());

            this.adjacentDictionary[fromNode].Add(toNode);
            this.adjacentDictionary[toNode].Add(fromNode);
        }
    }
}