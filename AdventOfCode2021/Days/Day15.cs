using System.Drawing;

namespace AdventOfCode2021.Days;

/// <summary>
/// Class representing the advent day 15.
/// </summary>
public class Day15 : AdventDay
{
    private int[,] riskLevels;

    private Dictionary<Point, int> totalRiskCache;

    /// <summary>
    /// Initializes the class representing the advent day 15.
    /// </summary>
    /// <param name="isExample">Should example input be used.</param>
    public Day15(bool isExample = false) : base(15, isExample)
    {
    }

    /// <summary>
    /// Solves the first part of the advent day puzzle.
    /// </summary>
    /// <returns>Puzzle result.</returns>
    public override string SolveFirstPart()
    {
        this.FillInRiskLevels();
        this.totalRiskCache = new Dictionary<Point, int>();

        var lowestTotalRisk = this.FindLowestTotalRisk(0, 0);

        lowestTotalRisk -= this.riskLevels[0, 0];

        return $"{lowestTotalRisk}";
    }

    /// <summary>
    /// Solves the second part of the advent day puzzle.
    /// </summary>
    /// <returns>Puzzle result.</returns>
    public override string SolveSecondPart()
    {
        this.FillInRiskLevels(true);
        this.totalRiskCache = new Dictionary<Point, int>();

        var lowestTotalRisk = this.FindLowestTotalRisk(0, 0);

        lowestTotalRisk -= this.riskLevels[0, 0];

        return $"{lowestTotalRisk}";
    }

    /// <summary>
    /// Finds lowest total risk starting from the given location to the bottom right matrix location.
    /// </summary>
    /// <param name="xLocation">X coordinate of the starting location.</param>
    /// <param name="yLocation">Y coordinate of the starting location.</param>
    /// <returns>Lowest total risk to the bottom right matrix location.</returns>
    private int FindLowestTotalRisk(int xLocation, int yLocation)
    {
        var rows = this.riskLevels.GetLength(0);
        var columns = this.riskLevels.GetLength(1);

        if (xLocation > columns - 1 || yLocation > rows - 1)
            return int.MaxValue;

        if (xLocation == columns - 1 && yLocation == rows - 1)
            return this.riskLevels[yLocation, xLocation];

        var point = new Point(xLocation, yLocation);

        if (this.totalRiskCache.ContainsKey(point))
        {
            return this.totalRiskCache[point];
        }

        var lowestTotalRisk = this.riskLevels[yLocation, xLocation]
                     + Math.Min(FindLowestTotalRisk(xLocation + 1, yLocation), FindLowestTotalRisk(xLocation, yLocation + 1));

        this.totalRiskCache.Add(point, lowestTotalRisk);

        return lowestTotalRisk;
    }

    /// <summary>
    /// Fills in the risk levels based on the puzzle input and the part of the puzzle that is being solved.
    /// </summary>
    /// <param name="isSecondPart">Is second part of the puzzle being solved flag.</param>
    private void FillInRiskLevels(bool isSecondPart = false)
    {
        var inputLines = this.InputContents
            .Split('\n', StringSplitOptions.TrimEntries);

        var riskLevelHeight = inputLines.Length;
        var riskLevelsWidth = inputLines.First().Length;

        if (!isSecondPart)
        {
            this.riskLevels = new int[riskLevelHeight, riskLevelsWidth];

            for (var i = 0; i < riskLevelHeight; i++)
            {
                for (var j = 0; j < riskLevelsWidth; j++)
                {
                    this.riskLevels[i, j] = int.Parse(inputLines[i][j].ToString());
                }
            }
        }
        else
        {
            this.riskLevels = new int[5 * riskLevelHeight, 5 * riskLevelsWidth];

            for (var i = 0; i < 5 * riskLevelHeight; i++)
            {
                for (var j = 0; j < 5 * riskLevelsWidth; j++)
                {
                    var xSection = j / riskLevelsWidth;
                    var ySection = i / riskLevelHeight;
                    
                    var newValue = (int.Parse(inputLines[i % riskLevelHeight][j % riskLevelsWidth].ToString()) + xSection + ySection);

                    if (newValue > 9) newValue %= 9;

                    this.riskLevels[i, j] = newValue;
                }
            }
        }
    }
}