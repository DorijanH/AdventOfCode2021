using System.Drawing;

namespace AdventOfCode2021.Days;

/// <summary>
/// Class representing the advent day 5.
/// </summary>
public class Day05 : AdventDay
{
    private readonly List<string> input;

    /// <summary>
    /// Initializes the class representing the advent day 5.
    /// </summary>
    /// <param name="isExample">Should example input be used.</param>
    public Day05(bool isExample = false) : base(5, isExample)
    {
        this.input = this.InputContents
            .Split('\n', StringSplitOptions.TrimEntries)
            .ToList();
    }

    /// <summary>
    /// Solves the first part of the advent day puzzle.
    /// </summary>
    /// <returns>Puzzle result.</returns>
    public override string SolveFirstPart()
    {
        var coordinateOccurrences = new Dictionary<Point, int>();

        foreach (var coordinateRange in this.input)
        {
            var coordinatesSplit = coordinateRange.Split("->", StringSplitOptions.TrimEntries);

            var fromXAndY = coordinatesSplit[0]
                .Split(',')
                .Select(int.Parse)
                .ToArray();
            var fromPoint = new Point(fromXAndY[0], fromXAndY[1]);

            var toXAndY = coordinatesSplit[1]
                .Split(',')
                .Select(int.Parse)
                .ToArray();
            var toPoint = new Point(toXAndY[0], toXAndY[1]);

            var pointsBetween = new List<Point>();

            // If the line is horizontal
            if (fromPoint.Y == toPoint.Y) pointsBetween = GetHorizontalPointsBetween(fromPoint, toPoint);
            
            // If the line is vertical
            else if (fromPoint.X == toPoint.X) pointsBetween = GetVerticalPointsBetween(fromPoint, toPoint);

            foreach (var point in pointsBetween)
            {
                if (coordinateOccurrences.ContainsKey(point))
                {
                    coordinateOccurrences[point]++;
                }
                else
                {
                    coordinateOccurrences.Add(point, 1);
                }
            }
        }

        var atLeastTwoOverlapCount = coordinateOccurrences.Count(cpo => cpo.Value >= 2);

        Console.WriteLine($"At least two lines overlap at: {atLeastTwoOverlapCount} points");

        return $"{atLeastTwoOverlapCount}";
    }

    /// <summary>
    /// Solves the second part of the advent day puzzle.
    /// </summary>
    /// <returns>Puzzle result.</returns>
    public override string SolveSecondPart()
    {
        var coordinateOccurrences = new Dictionary<Point, int>();

        foreach (var coordinateRange in this.input)
        {
            var coordinatesSplit = coordinateRange.Split("->", StringSplitOptions.TrimEntries);

            var fromXAndY = coordinatesSplit[0]
                .Split(',')
                .Select(int.Parse)
                .ToArray();
            var fromPoint = new Point(fromXAndY[0], fromXAndY[1]);

            var toXAndY = coordinatesSplit[1]
                .Split(',')
                .Select(int.Parse)
                .ToArray();
            var toPoint = new Point(toXAndY[0], toXAndY[1]);

            List<Point> pointsBetween;

            // If the line is horizontal
            if (fromPoint.Y == toPoint.Y) pointsBetween = GetHorizontalPointsBetween(fromPoint, toPoint);

            // If the line is vertical
            else if (fromPoint.X == toPoint.X) pointsBetween = GetVerticalPointsBetween(fromPoint, toPoint);

            // The line is diagonal
            else pointsBetween = GetDiagonalPointsBetween(fromPoint, toPoint);

            foreach (var point in pointsBetween)
            {
                if (coordinateOccurrences.ContainsKey(point))
                {
                    coordinateOccurrences[point]++;
                }
                else
                {
                    coordinateOccurrences.Add(point, 1);
                }
            }
        }

        var atLeastTwoOverlapCount = coordinateOccurrences.Count(cpo => cpo.Value >= 2);

        Console.WriteLine($"At least two lines overlap at: {atLeastTwoOverlapCount} points");

        return $"{atLeastTwoOverlapCount}";
    }

    /// <summary>
    /// Gets the horizontal points between two coordinate points.
    /// </summary>
    /// <param name="startingPoint">Starting coordinate point.</param>
    /// <param name="endingPoint">Ending coordinate point.</param>
    /// <returns>Coordinate points between (inclusive).</returns>
    private static List<Point> GetHorizontalPointsBetween(Point startingPoint, Point endingPoint)
    {
        var horizontalPointsBetween = new List<Point>();

        var startingX = Math.Min(startingPoint.X, endingPoint.X);
        var endingX = Math.Max(startingPoint.X, endingPoint.X);

        for (var x = startingX; x <= endingX; x++)
        {
            horizontalPointsBetween.Add(new Point(x, startingPoint.Y));
        }

        return horizontalPointsBetween;
    }

    /// <summary>
    /// Gets the vertical points between two coordinate points.
    /// </summary>
    /// <param name="startingPoint">Starting coordinate point.</param>
    /// <param name="endingPoint">Ending coordinate point.</param>
    /// <returns>Coordinate points between (inclusive).</returns>
    private static List<Point> GetVerticalPointsBetween(Point startingPoint, Point endingPoint)
    {
        var verticalPointsBetween = new List<Point>();

        var startingY = Math.Min(startingPoint.Y, endingPoint.Y);
        var endingY = Math.Max(startingPoint.Y, endingPoint.Y);

        for (var y = startingY; y <= endingY; y++)
        {
            verticalPointsBetween.Add(new Point(startingPoint.X, y));
        }

        return verticalPointsBetween;
    }

    /// <summary>
    /// Gets the diagonal points between two coordinate points.
    /// </summary>
    /// <param name="startingPoint">Starting coordinate point.</param>
    /// <param name="endingPoint">Ending coordinate point.</param>
    /// <returns>Coordinate points between (inclusive).</returns>
    private static List<Point> GetDiagonalPointsBetween(Point startingPoint, Point endingPoint)
    {
        var diagonalPointsBetween = new List<Point>();

        var pointsDistance = Math.Abs(startingPoint.X - endingPoint.X);
        var stepX = startingPoint.X < endingPoint.X ? 1 : -1;
        var stepY = startingPoint.Y < endingPoint.Y ? 1 : -1;

        for (var i = 0; i <= pointsDistance; i++)
        {
            var x = startingPoint.X + i * stepX;
            var y = startingPoint.Y + i * stepY;

            diagonalPointsBetween.Add(new Point(x, y));
        }

        return diagonalPointsBetween;
    }
}