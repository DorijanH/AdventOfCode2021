namespace AdventOfCode2021.Days;

/// <summary>
/// Class representing the advent day 7.
/// </summary>
public class Day7 : AdventDay
{
    private readonly int[] inputs;

    /// <summary>
    /// Initializes the class representing the advent day 7.
    /// </summary>
    /// <param name="isExample">Should example input be used.</param>
    public Day7(bool isExample = false) : base(7, isExample)
    {
        this.inputs = this.InputContents
            .Split(',', StringSplitOptions.TrimEntries)
            .Select(int.Parse)
            .ToArray();
    }

    /// <summary>
    /// Solves the first part of the advent day puzzle.
    /// </summary>
    /// <returns>Puzzle result.</returns>
    public override string SolveFirstPart()
    {
        var cheapestPositionToAlignTo = this.inputs[0];
        var minFuelSpent = int.MaxValue;

        var minInput = this.inputs.Min();
        var maxInput = this.inputs.Max();
        var possiblePositions = Enumerable.Range(minInput, maxInput - minInput + 1);

        foreach (var position in possiblePositions)
        {
            var fuelSum = this.inputs.Sum(i => Math.Abs(i - position));

            if (fuelSum < minFuelSpent)
            {
                minFuelSpent = fuelSum;
                cheapestPositionToAlignTo = position;
            }
        }

        Console.WriteLine($"Cheapest position to align to is: {cheapestPositionToAlignTo}");
        Console.WriteLine($"Fuel spent: {minFuelSpent}");

        return $"{minFuelSpent}";
    }

    /// <summary>
    /// Solves the second part of the advent day puzzle.
    /// </summary>
    /// <returns>Puzzle result.</returns>
    public override string SolveSecondPart()
    {
        var cheapestPositionToAlignTo = this.inputs[0];
        var minFuelSpent = int.MaxValue;

        var minInput = this.inputs.Min();
        var maxInput = this.inputs.Max();
        var possiblePositions = Enumerable.Range(minInput, maxInput - minInput + 1);

        foreach (var position in possiblePositions)
        {
            var fuelSum = this.inputs
                .Select(i => Math.Abs(i - position) + 1)
                .Select(movesRequired => movesRequired * (movesRequired - 1) / 2)
                .Sum();

            if (fuelSum < minFuelSpent)
            {
                minFuelSpent = fuelSum;
                cheapestPositionToAlignTo = position;
            }
        }

        Console.WriteLine($"Cheapest position to align to is: {cheapestPositionToAlignTo}");
        Console.WriteLine($"Fuel spent: {minFuelSpent}");

        return $"{minFuelSpent}";
    }
}