namespace AdventOfCode2021.Days;

/// <summary>
/// Class representing the advent day 10.
/// </summary>
public class Day10 : AdventDay
{
    private readonly string[] input;

    private readonly Dictionary<char, char> matchingCharacters = new()
    {
        { '(', ')' }, { '[', ']' }, { '{', '}' }, { '<', '>' }
    };
    private readonly Dictionary<char, int> syntaxErrorScoring = new()
    {
        { ')', 3 }, { ']', 57 }, { '}', 1197 }, { '>', 25137 }
    };
    private readonly Dictionary<char, int> autocompleteScoring = new()
    {
        { ')', 1 }, { ']', 2 }, { '}', 3 }, { '>', 4 }
    };

    /// <summary>
    /// Initializes the class representing the advent day 10.
    /// </summary>
    /// <param name="isExample">Should example input be used.</param>
    public Day10(bool isExample = false) : base(10, isExample)
    {
        this.input = this.InputContents
            .Split('\n', StringSplitOptions.TrimEntries);
    }

    /// <summary>
    /// Solves the first part of the advent day puzzle.
    /// </summary>
    /// <returns>Puzzle result.</returns>
    public override string SolveFirstPart()
    {
        var syntaxErrorScore = 0;

        foreach (var line in this.input)
        {
            var stack = new Stack<char>();

            foreach (var character in line)
            {
                // If the character is one of the opening characters, push it to the stack
                if (this.matchingCharacters.ContainsKey(character))
                {
                    stack.Push(character);
                }
                else
                {
                    // If not, check if it is the closing version of the latest character on the stack
                    // If not, that's the illegal character
                    if (this.matchingCharacters[stack.Pop()] != character)
                    {
                        syntaxErrorScore += this.syntaxErrorScoring[character];
                    }
                }
            }
        }

        Console.WriteLine($"Total syntax error score is: {syntaxErrorScore}");

        return $"{syntaxErrorScore}";
    }

    /// <summary>
    /// Solves the second part of the advent day puzzle.
    /// </summary>
    /// <returns>Puzzle result.</returns>
    public override string SolveSecondPart()
    {
        var completionScoring = new List<long>();

        foreach (var line in this.input)
        {
            var stack = new Stack<char>();

            foreach (var character in line)
            {
                // If the character is one of the opening characters, push it to the stack
                if (this.matchingCharacters.ContainsKey(character))
                {
                    stack.Push(character);
                }
                else
                {
                    // If not, check if it is the closing version of the latest character on the stack
                    // If not, that's the corrupted line, skip it.
                    if (this.matchingCharacters[stack.Pop()] != character)
                    {
                        stack.Clear();
                        break;
                    }
                }
            }

            // The line is incomplete (stack is not empty, there are missing closing characters)
            if (stack.Count != 0)
            {
                var score = 0L;

                while (stack.Count > 0)
                {
                    score = score * 5 + this.autocompleteScoring[this.matchingCharacters[stack.Pop()]];
                }

                completionScoring.Add(score);
            }
        }

        var sortedCompletionScoring = completionScoring.OrderByDescending(s => s).ToList();
        var middleScore = sortedCompletionScoring[sortedCompletionScoring.Count / 2];

        Console.WriteLine($"The middle score is: {middleScore}");

        return $"{middleScore}";
    }
}