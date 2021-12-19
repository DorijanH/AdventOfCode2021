namespace AdventOfCode2021.Days;

/// <summary>
/// Class representing the advent day 14.
/// </summary>
public class Day14 : AdventDay
{
    private readonly string polymerTemplate;
    private readonly Dictionary<string, string> insertionRules = new();
    private Dictionary<string, long> characterCounter;

    /// <summary>
    /// Initializes the class representing the advent day 14.
    /// </summary>
    /// <param name="isExample">Should example input be used.</param>
    public Day14(bool isExample = false) : base(14, isExample)
    {
        var inputSections = this.InputContents
            .Replace("\r", "")
            .Split("\n\n", StringSplitOptions.TrimEntries);

        this.polymerTemplate = inputSections[0];

        // Fill in the pair insertion rules.
        foreach (var instruction in inputSections[1].Split('\n', StringSplitOptions.TrimEntries))
        {
            var instructionSplit = instruction.Split("->", StringSplitOptions.TrimEntries);

            this.insertionRules.Add(instructionSplit[0], instructionSplit[1]);
        }
    }

    /// <summary>
    /// Solves the first part of the advent day puzzle.
    /// </summary>
    /// <returns>Puzzle result.</returns>
    public override string SolveFirstPart()
    {
        this.FillInCharacterCounter();

        this.ApplyInsertionRules(this.polymerTemplate, 10);

        var maxElementCount = this.characterCounter.MaxBy(cc => cc.Value);
        var minElementCount = this.characterCounter.MinBy(cc => cc.Value);

        Console.WriteLine($"Most common element ({maxElementCount.Key}, {maxElementCount.Value})");
        Console.WriteLine($"Least common element ({minElementCount.Key}, {minElementCount.Value})");

        return $"{maxElementCount.Value - minElementCount.Value}";
    }

    /// <summary>
    /// Solves the second part of the advent day puzzle.
    /// </summary>
    /// <returns>Puzzle result.</returns>
    public override string SolveSecondPart()
    {
        this.FillInCharacterCounter();

        this.ApplyInsertionRules(this.polymerTemplate, 40);

        var maxElementCount = this.characterCounter.MaxBy(cc => cc.Value);
        var minElementCount = this.characterCounter.MinBy(cc => cc.Value);

        Console.WriteLine($"Most common element ({maxElementCount.Key}, {maxElementCount.Value})");
        Console.WriteLine($"Least common element ({minElementCount.Key}, {minElementCount.Value})");

        return $"{maxElementCount.Value - minElementCount.Value}";
    }

    /// <summary>
    /// Applies the insertion rules on the polymer string.
    /// </summary>
    /// <param name="polymerString">Polymer string to apply insertion rules on.</param>
    /// <param name="stepsCount">Number of insertion rules iterations.</param>
    private void ApplyInsertionRules(string polymerString, int stepsCount)
    {
        var polymerPairs = this.ChunksFromPolymer(polymerString);

        for (var i = 0; i < stepsCount; i++)
        {
            var newPolymerPairs = new Dictionary<string, long>();

            foreach (var polymerPair in polymerPairs)
            {
                var elementToInsert = this.insertionRules[polymerPair.Key];
                var firstNewPair = $"{polymerPair.Key[0]}{elementToInsert}";
                var secondNewPair = $"{elementToInsert}{polymerPair.Key[1]}";

                this.AddOrUpdateDictionary(newPolymerPairs, firstNewPair, polymerPair.Value);
                this.AddOrUpdateDictionary(newPolymerPairs, secondNewPair, polymerPair.Value);

                this.AddOrUpdateDictionary(this.characterCounter, elementToInsert, polymerPair.Value);
            }

            polymerPairs = newPolymerPairs;
        }
    }

    /// <summary>
    /// Get the initial chunks from the polymer string.
    /// </summary>
    /// <param name="polymerString">Polymer string to split into chunks.</param>
    /// <returns>Dictionary containing the polymer string chunks and the number of their occurrences.</returns>
    private Dictionary<string, long> ChunksFromPolymer(string polymerString)
    {
        var pairs = new Dictionary<string, long>();

        for (var i = 0; i < polymerString.Length - 1; i++)
        {
            var firstChar = polymerString[i];
            var secondChar = polymerString[i + 1];

            this.AddOrUpdateDictionary(pairs, $"{firstChar}{secondChar}");
        }

        return pairs;
    }

    /// <summary>
    /// Helper method to add or update to the dictionary without checking if the key exists.
    /// </summary>
    /// <param name="dictionaryToAddOrUpdate">Dictionary to add or update to.</param>
    /// <param name="dictionaryKey">Dictionary key for which to add or update counter.</param>
    /// <param name="valueToAdd">Value to add to the dictionary key.</param>
    private void AddOrUpdateDictionary(IDictionary<string, long> dictionaryToAddOrUpdate, string dictionaryKey, long valueToAdd = 1)
    {
        dictionaryToAddOrUpdate.TryGetValue(dictionaryKey, out var currentCount);
        dictionaryToAddOrUpdate[dictionaryKey] = currentCount + valueToAdd;
    }

    /// <summary>
    /// Fills in the character counter dictionary to use.
    /// </summary>
    private void FillInCharacterCounter()
    {
        this.characterCounter = new();

        // Fill initial character counters.
        foreach (var character in this.polymerTemplate)
        {
            this.AddOrUpdateDictionary(this.characterCounter, $"{character}");
        }
    }
}