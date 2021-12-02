namespace AdventOfCode2021.Days;

/// <summary>
/// Class representing the advent day 1.
/// </summary>
public class Day1 : AdventDay
{
    private readonly int[] input;

    /// <summary>
    /// Initializes the class representing the advent day 1.
    /// </summary>
    /// <param name="isExample">Should example input be used.</param>
    public Day1(bool isExample = false) : base(1, isExample)
    {
        this.input = this.InputContents
            .Split('\n', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
    }

    /// <summary>
    /// Solves the first part of the advent day puzzle.
    /// </summary>
    /// <returns>Puzzle result.</returns>
    public override string SolveFirstPart()
    {
        var count = 0;

        for (var i = 1; i < this.input.Length; i++)
        {
            if (this.input[i] > this.input[i - 1]) count++;
        }

        return $"{count}";
    }

    /// <summary>
    /// Solves the second part of the advent day puzzle.
    /// </summary>
    /// <returns>Puzzle result.</returns>
    public override string SolveSecondPart()
    {
        var count = 0;
        var prevSum = this.input[..3].Sum();

        for (var i = 1; i < this.input.Length - 2; i++)
        {
            var sum = this.input[i..(i + 3)].Sum();

            if (sum > prevSum) count++;

            prevSum = sum;
        }

        return $"{count}";
    }
}