namespace AdventOfCode2021.Days;

/// <summary>
/// Class representing the advent day 9.
/// </summary>
public class Day9 : AdventDay
{
    private readonly int[,] input;
    private HashSet<string> checkedPoints;

    /// <summary>
    /// Initializes the class representing the advent day 9.
    /// </summary>
    /// <param name="isExample">Should example input be used.</param>
    public Day9(bool isExample = false) : base(9, isExample)
    {
        var inputLines = this.InputContents
            .Split('\n', StringSplitOptions.TrimEntries);

        this.input = new int[inputLines.Length, inputLines.First().Length];

        for(var i = 0; i < inputLines.Length; i++)
        {
            for (var j = 0; j < inputLines[i].Length; j++)
            {
                this.input[i, j] = int.Parse(inputLines[i][j].ToString());
            }
        }
    }

    /// <summary>
    /// Solves the first part of the advent day puzzle.
    /// </summary>
    /// <returns>Puzzle result.</returns>
    public override string SolveFirstPart()
    {
        var lowPoints = new List<int>();

        var rows = this.input.GetLength(0);
        var columns = this.input.GetLength(1);

        // Finding the lowest point
        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < columns; j++)
            {
                var pointOfInterest = this.input[i, j];

                // Checking up
                if (i - 1 >= 0 && this.input[i - 1, j] <= pointOfInterest) continue;

                // Checking down
                if (i + 1 < rows && this.input[i + 1, j] <= pointOfInterest) continue;

                // Checking left
                if (j - 1 >= 0 && this.input[i, j - 1] <= pointOfInterest) continue;

                // Checking right
                if (j + 1 < columns && this.input[i, j + 1] <= pointOfInterest) continue;

                // Found the lowest point
                lowPoints.Add(pointOfInterest);
            }
        }

        var riskLevelsSum = lowPoints.Sum(lp => lp + 1);

        Console.WriteLine($"The sum of risk levels of all low points in the heightmap is: {riskLevelsSum}");

        return $"{riskLevelsSum}";
    }

    /// <summary>
    /// Solves the second part of the advent day puzzle.
    /// </summary>
    /// <returns>Puzzle result.</returns>
    public override string SolveSecondPart()
    {
        var sizeOfBasins = new List<int>();

        var rows = this.input.GetLength(0);
        var columns = this.input.GetLength(1);

        // Finding the lowest point
        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < columns; j++)
            {
                var pointOfInterest = this.input[i, j];

                // Checking up
                if (i - 1 >= 0 && this.input[i - 1, j] <= pointOfInterest) continue;

                // Checking down
                if (i + 1 < rows && this.input[i + 1, j] <= pointOfInterest) continue;

                // Checking left
                if (j - 1 >= 0 && this.input[i, j - 1] <= pointOfInterest) continue;

                // Checking right
                if (j + 1 < columns && this.input[i, j + 1] <= pointOfInterest) continue;

                // Found the lowest point
                this.checkedPoints = new HashSet<string>();

                sizeOfBasins.Add(this.FindBasinsSize(rows, columns, j, i));
            }
        }

        var threeLargestBasins = sizeOfBasins.OrderByDescending(i => i)
            .Take(3)
            .ToList();

        var threeLargestBasinsSum = threeLargestBasins.Aggregate(1, (a, b) => a * b);

        Console.WriteLine($"Multiplication of three largest basins sizes gives: {threeLargestBasinsSum}");

        return $"{threeLargestBasinsSum}";
    }

    /// <summary>
    /// Recursion method to find the size of the basin that starts with the lowest point and expands in the adjacent positions.
    /// Basin stops if we reach out of bounds or if we reach number 9.
    /// </summary>
    /// <param name="rows">Number of matrix rows.</param>
    /// <param name="columns">Number of matrix columns.</param>
    /// <param name="xLocation">X coordinate of the checking matrix point.</param>
    /// <param name="yLocation">Y coordinate of the checking matrix point.</param>
    /// <returns></returns>
    private int FindBasinsSize(int rows, int columns, int xLocation, int yLocation)
    {
        var sizeOfTheBasin = 0;

        // If we already checked this matrix point, if we are out of bounds or if we are number 9 stop the recursion
        if (this.HaveVisited(xLocation, yLocation)
            || xLocation < 0
            || xLocation >= columns
            || yLocation < 0
            || yLocation >= rows
            || this.input[yLocation, xLocation] == 9)
            return 0;

        sizeOfTheBasin++;
        this.checkedPoints.Add($"({xLocation}, {yLocation})");

        // Recursive calls
        sizeOfTheBasin += this.FindBasinsSize(rows, columns, xLocation - 1, yLocation);
        sizeOfTheBasin += this.FindBasinsSize(rows, columns, xLocation + 1, yLocation);
        sizeOfTheBasin += this.FindBasinsSize(rows, columns, xLocation, yLocation - 1);
        sizeOfTheBasin += this.FindBasinsSize(rows, columns, xLocation, yLocation + 1);

        return sizeOfTheBasin;
    }

    /// <summary>
    /// Checks if the matrix point was already visited.
    /// </summary>
    /// <param name="xLocation">X coordinate of the matrix point location.</param>
    /// <param name="yLocation">Y coordinate of the matrix point location.</param>
    /// <returns>Boolean representing was the matrix point already visited.</returns>
    private bool HaveVisited(int xLocation, int yLocation)
    {
        return this.checkedPoints.Contains($"({xLocation}, {yLocation})");
    }
}