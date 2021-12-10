using System.Text;

namespace AdventOfCode2021.Days;

/// <summary>
/// Class representing the advent day 8.
/// </summary>
public class Day8 : AdventDay
{
    private readonly Dictionary<string, string> input;

    /// <summary>
    /// Initializes the class representing the advent day 8.
    /// </summary>
    /// <param name="isExample">Should example input be used.</param>
    public Day8(bool isExample = false) : base(8, isExample)
    {
        this.input = this.InputContents
            .Split('\n', StringSplitOptions.TrimEntries)
            .Select(line => line.Split('|', StringSplitOptions.TrimEntries))
            .ToDictionary(lineParts => lineParts[0], lineParts => lineParts[1]);
    }

    /// <summary>
    /// Solves the first part of the advent day puzzle.
    /// </summary>
    /// <returns>Puzzle result.</returns>
    public override string SolveFirstPart()
    {
        var easyDigitsAppearanceCount = 0;

        foreach (var outputValues in this.input.Values)
        {
            foreach (var outputValue in outputValues.Split(' ', StringSplitOptions.TrimEntries))
            {
                if (outputValue.Length is 2 or 3 or 4 or 7) easyDigitsAppearanceCount++;
            }
        }

        Console.WriteLine($"Easy digits (1, 4, 7, 8) appearance count: {easyDigitsAppearanceCount}");

        return $"{easyDigitsAppearanceCount}";
    }

    /// <summary>
    /// Solves the second part of the advent day puzzle.
    /// </summary>
    /// <returns>Puzzle result.</returns>
    public override string SolveSecondPart()
    {
        var allOutputValuesSum = 0;

        foreach (var uniquePatterns in this.input.Keys)
        {
            var onePattern = string.Empty;
            var fourPattern = string.Empty;
            var sevenPattern = string.Empty;
            var eightPattern = string.Empty;
            var uniquePatternsSplit = uniquePatterns.Split(' ', StringSplitOptions.TrimEntries);

            // Find the easy digit patterns.
            foreach (var uniquePattern in uniquePatternsSplit)
            {
                switch (uniquePattern.Length)
                {
                    case 2:
                        onePattern = uniquePattern;
                        break;
                    case 3:
                        sevenPattern = uniquePattern;
                        break;
                    case 4:
                        fourPattern = uniquePattern;
                        break;
                    case 7:
                        eightPattern = uniquePattern;
                        break;
                }
            }

            var fourAndSevenPatternDifference = fourPattern.ToCharArray()
                .Except(sevenPattern.ToCharArray())
                .ToArray();

            var outputValuesSplit = this.input[uniquePatterns].Split(' ', StringSplitOptions.TrimEntries);
            var decodedNumberStringBuilder = new StringBuilder(outputValuesSplit.Length);

            // Decode the number represented by the output values part of the input
            foreach (var outputValue in outputValuesSplit)
            {
                switch (outputValue.Length)
                {
                    case 2:
                        decodedNumberStringBuilder.Append(1);
                        break;
                    case 3:
                        decodedNumberStringBuilder.Append(7);
                        break;
                    case 4:
                        decodedNumberStringBuilder.Append(4);
                        break;
                    case 5:
                        decodedNumberStringBuilder.Append(DecodeFiveLetterPattern(onePattern, outputValue,
                            fourAndSevenPatternDifference));
                        break;
                    case 6:
                        decodedNumberStringBuilder.Append(
                            DecodeSixLetterPattern(sevenPattern, fourPattern, outputValue));
                        break;
                    case 7:
                        decodedNumberStringBuilder.Append(8);
                        break;
                }
            }

            allOutputValuesSum += int.Parse($"{decodedNumberStringBuilder}");
        }

        Console.WriteLine($"Result of adding up all of the decoded output values: {allOutputValuesSum}");

        return $"{allOutputValuesSum}";
    }

    /// <summary>
    /// Decodes the five letter output value pattern that can be either number 2, 3 or 5.
    /// </summary>
    /// <param name="onePattern">Patter that represents number 1.</param>
    /// <param name="patternToDecode">Pattern to decode.</param>
    /// <param name="fourAndSevenPatterDifference">Difference between patter for number 4 and 7.</param>
    /// <returns>Number the patter to decode encodes.</returns>
    private static int DecodeFiveLetterPattern(string onePattern, string patternToDecode, IEnumerable<char> fourAndSevenPatterDifference)
    {
        // If the pattern to decode contains all of the letters from the patter for number 1
        if (onePattern.ToCharArray().All(patternToDecode.Contains)) return 3;

        if (fourAndSevenPatterDifference.All(patternToDecode.Contains)) return 5;

        return 2;
    }

    /// <summary>
    /// Decodes the six letter output value pattern that can be either number 0, 6 or 9.
    /// </summary>
    /// <param name="sevenPattern">Patter that represents number 7.</param>
    /// <param name="fourPattern">Patter that represents number 4.</param>
    /// <param name="patternToDecode">Pattern to decode.</param>
    /// <returns>Number the patter to decode encodes.</returns>
    private static int DecodeSixLetterPattern(string sevenPattern, string fourPattern, string patternToDecode)
    {
        // If the pattern to decode doesn't contain all of the letters from the patter for number 7
        if (!sevenPattern.ToCharArray().All(patternToDecode.Contains)) return 6;

        if (fourPattern.ToCharArray().All(patternToDecode.Contains)) return 9;

        return 0;
    }
}