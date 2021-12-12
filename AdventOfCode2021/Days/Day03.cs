using System.Text;

namespace AdventOfCode2021.Days;

/// <summary>
/// Class representing the advent day 3.
/// </summary>
public class Day03 : AdventDay
{
    private readonly List<string> input;

    /// <summary>
    /// Initializes the class representing the advent day 3.
    /// </summary>
    /// <param name="isExample">Should example input be used.</param>
    public Day03(bool isExample = false) : base(3, isExample)
    {
        this.input = this.InputContents
            .Split('\n', StringSplitOptions.RemoveEmptyEntries)
            .Select(i => i.Trim())
            .ToList();
    }

    /// <summary>
    /// Solves the first part of the advent day puzzle.
    /// </summary>
    /// <returns>Puzzle result.</returns>
    public override string SolveFirstPart()
    {
        var binaryNumbersLength = this.input.First().Length;

        var gammaRate = new StringBuilder(binaryNumbersLength);
        var epsilonRate = new StringBuilder(binaryNumbersLength);

        for (var i = 0; i < binaryNumbersLength; i++)
        {
            var sumOfNumbersAtIndex = this.input.Sum(binary => int.Parse($"{binary[i]}"));

            if (2 * sumOfNumbersAtIndex > this.input.Count)
            {
                // Most common bit is 1
                gammaRate.Append('1');
                epsilonRate.Append('0');
            }
            else
            {
                // Most common bit is 0
                gammaRate.Append('0');
                epsilonRate.Append('1');
            }
        }

        var gammaRateDecimal = Convert.ToInt32(gammaRate.ToString(), 2);
        var epsilonRateDecimal = Convert.ToInt32(epsilonRate.ToString(), 2);

        return $"{gammaRateDecimal * epsilonRateDecimal}";
    }

    /// <summary>
    /// Solves the second part of the advent day puzzle.
    /// </summary>
    /// <returns>Puzzle result.</returns>
    public override string SolveSecondPart()
    {
        var binaryNumbersLength = this.input.First().Length;

        var oxygenGeneratorRatings = this.input;
        var co2ScrubberRatings = this.input;

        for (var i = 0; i < binaryNumbersLength; i++)
        {
            var sumOfOxygenGeneratorRatingsAtIndex = oxygenGeneratorRatings.Sum(binary => int.Parse($"{binary[i]}"));
            var sumOfCo2ScrubberRatingsAtIndex = co2ScrubberRatings.Sum(binary => int.Parse($"{binary[i]}"));

            // Oxygen generator ratings
            if (oxygenGeneratorRatings.Count != 1)
            {
                oxygenGeneratorRatings = 2 * sumOfOxygenGeneratorRatingsAtIndex >= oxygenGeneratorRatings.Count
                    // Most common bit is 1 or the bits are equally common
                    ? oxygenGeneratorRatings.Where(binary => binary[i] == '1').ToList()
                    : oxygenGeneratorRatings.Where(binary => binary[i] == '0').ToList();
            }

            // CO2 scrubber ratings
            if (co2ScrubberRatings.Count != 1)
            {
                co2ScrubberRatings = 2 * sumOfCo2ScrubberRatingsAtIndex >= co2ScrubberRatings.Count
                    // Most common bit is 1 or the bits are equally common
                    ? co2ScrubberRatings.Where(binary => binary[i] == '0').ToList()
                    : co2ScrubberRatings.Where(binary => binary[i] == '1').ToList();
            }

            if (oxygenGeneratorRatings.Count == 1 && co2ScrubberRatings.Count == 1) break;
        }

        var oxygenGeneratorRatingDecimal = Convert.ToInt32(oxygenGeneratorRatings.First(), 2);
        var co2ScrubberRatingDecimal = Convert.ToInt32(co2ScrubberRatings.First(), 2);

        return $"{oxygenGeneratorRatingDecimal * co2ScrubberRatingDecimal}";
    }
}