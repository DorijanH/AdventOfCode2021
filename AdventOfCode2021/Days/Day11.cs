namespace AdventOfCode2021.Days;

/// <summary>
/// Class representing the advent day 11.
/// </summary>
public class Day11 : AdventDay
{
    private readonly string[] input;
    private HashSet<string> flashedOctopuses;

    /// <summary>
    /// Initializes the class representing the advent day 11.
    /// </summary>
    /// <param name="isExample">Should example input be used.</param>
    public Day11(bool isExample = false) : base(11, isExample)
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
        var initialEnergies = this.InitialEnergies();

        const int stepsCount = 100;
        var flashesCount = 0;

        for (var i = 0; i < stepsCount; i++)
        {
            flashesCount += this.SimulateStep(initialEnergies);
        }

        Console.WriteLine($"There were a total of: {flashesCount} after {stepsCount} steps");

        return $"{flashesCount}";
    }

    /// <summary>
    /// Solves the second part of the advent day puzzle.
    /// </summary>
    /// <returns>Puzzle result.</returns>
    public override string SolveSecondPart()
    {
        var initialEnergies = this.InitialEnergies();

        for (var i = 1;; i++)
        {
            var flashesCount = this.SimulateStep(initialEnergies);

            if (flashesCount == 100)
            {
                Console.WriteLine($"After step {i} all octopuses flash simultaneously");
                return $"{i}";
            }
        }
    }

    /// <summary>
    /// Simulates the step and increases the initial energies accordingly.
    /// </summary>
    /// <param name="energies">Current state of the octopus energies.</param>
    /// <returns>Number of flashes occurred this step.</returns>
    private int SimulateStep(int[,] energies)
    {
        // First, increase all energy levels by 1
        for (var i = 0; i < 10; i++)
        {
            for (var j = 0; j < 10; j++)
            {
                energies[i, j] += 1;
            }
        }

        this.flashedOctopuses = new HashSet<string>();
        var flashCounts = 0;
        bool flashOccurred;
        do
        {
            flashOccurred = false;

            // Energy levels greater than 9 flash
            for (var y = 0; y < 10; y++)
            {
                for (var x = 0; x < 10; x++)
                {
                    if (energies[y, x] > 9)
                    {
                        flashCounts++;
                        flashOccurred = true;
                        this.flashedOctopuses.Add($"({x}, {y})");

                        energies[y, x] = 0;

                        // Increase up
                        if (y - 1 >= 0 && !this.HasFlashed(x, y - 1)) energies[y - 1, x]++;
                        
                        // Increase right
                        if (x + 1 < 10 && !this.HasFlashed(x + 1, y)) energies[y, x + 1]++;

                        // Increase down
                        if (y + 1 < 10 && !this.HasFlashed(x, y + 1)) energies[y + 1, x]++;

                        // Increase left
                        if (x - 1 >= 0 && !this.HasFlashed(x - 1, y)) energies[y, x - 1]++;

                        // Increase top-right
                        if (y - 1 >= 0 && x + 1 < 10 && !this.HasFlashed(x + 1, y - 1)) energies[y - 1, x + 1]++;

                        // Increase down-right
                        if (y + 1 < 10 && x + 1 < 10 && !this.HasFlashed(x + 1, y + 1)) energies[y + 1, x + 1]++;

                        // Increase down-left
                        if (y + 1 < 10 && x - 1 >= 0 && !this.HasFlashed(x - 1, y + 1)) energies[y + 1, x - 1]++;

                        // Increase top-left
                        if (y - 1 >= 0 && x - 1 >= 0 && !this.HasFlashed(x - 1, y - 1)) energies[y - 1, x - 1]++;
                    }
                }
            }
        } while (flashOccurred);
        

        return flashCounts;
    }

    /// <summary>
    /// Checks if the octopus has already flashed.
    /// </summary>
    /// <param name="x">X coordinate of the octopus matrix location.</param>
    /// <param name="y">Y coordinate of the octopus matrix location.</param>
    /// <returns>Boolean representing has the octopus already flashed.</returns>
    private bool HasFlashed(int x, int y)
    {
        return this.flashedOctopuses.Contains($"({x}, {y})");
    }

    /// <summary>
    /// Gets the initial energies matrix from the puzzle input.
    /// </summary>
    /// <returns>Initial puzzle input's energies.</returns>
    private int[,] InitialEnergies()
    {
        var energies = new int[10, 10];

        for (var i = 0; i < 10; i++)
        {
            for (var j = 0; j < 10; j++)
            {
                energies[i, j] = int.Parse(this.input[i][j].ToString());
            }
        }

        return energies;
    }
}