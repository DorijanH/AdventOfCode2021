using System.Drawing;

namespace AdventOfCode2021.Days;

/// <summary>
/// Class representing the advent day 13.
/// </summary>
public class Day13 : AdventDay
{
    private HashSet<Point> paperDots = new();
    private readonly List<string> foldingInstructions = new();

    private readonly int paperWidth;
    private readonly int paperHeight;

    /// <summary>
    /// Initializes the class representing the advent day 13.
    /// </summary>
    /// <param name="isExample">Should example input be used.</param>
    public Day13(bool isExample = false) : base(13, isExample)
    {
        var inputSections = this.InputContents
            .Replace("\r", "")
            .Split("\n\n", StringSplitOptions.TrimEntries)
            .ToList();

        this.FillInTheDotsAndInstructions();

        // Find the paper width and height.
        this.paperWidth = this.paperDots.Max(p => p.X) + 1;
        this.paperHeight = this.paperDots.Max(p => p.Y) + 1;
    }

    /// <summary>
    /// Solves the first part of the advent day puzzle.
    /// </summary>
    /// <returns>Puzzle result.</returns>
    public override string SolveFirstPart()
    {
        var foldingInstruction = this.foldingInstructions[0];

        var instructionSplit = foldingInstruction.Split('=');
        var foldingAxis = instructionSplit[0];
        var foldingPosition = int.Parse(instructionSplit[1]);

        this.FoldPaper(foldingAxis, foldingPosition);

        var dotsCount = this.paperDots.Count;

        Console.WriteLine($"After the first fold instruction there are {dotsCount} dots");

        return $"{dotsCount}";
    }

    /// <summary>
    /// Solves the second part of the advent day puzzle.
    /// </summary>
    /// <returns>Puzzle result.</returns>
    public override string SolveSecondPart()
    {
        this.FillInTheDotsAndInstructions();

        foreach (var foldingInstruction in this.foldingInstructions)
        {
            var instructionsSplit = foldingInstruction.Split('=');
            var foldingAxis = instructionsSplit[0];
            var foldingPosition = int.Parse(instructionsSplit[1]);

            this.FoldPaper(foldingAxis, foldingPosition);
        }

        this.PrintTheDots();

        var dotsCount = this.paperDots.Count;

        Console.WriteLine($"After all the folding instructions there are {dotsCount} dots");

        return $"{dotsCount}";
    }

    /// <summary>
    /// Folds the paper and makes new dots.
    /// </summary>
    /// <param name="foldingAxis">Axis along which the paper is being fold.</param>
    /// <param name="foldingPosition">Position at which the fold is being made.</param>
    private void FoldPaper(string foldingAxis, int foldingPosition)
    {
        var newDots = new HashSet<Point>();

        for (var y = 0; y < this.paperHeight; y++)
        {
            for (var x = 0; x < this.paperWidth; x++)
            {
                switch (foldingAxis)
                {
                    case "x" when x < foldingPosition:
                    {
                        if (this.paperDots.Contains(new Point(x, y)) ||
                            this.paperDots.Contains(new Point(foldingPosition - (x - foldingPosition), y)))
                            newDots.Add(new Point(x, y));
                        break;
                    }
                    case "y" when y < foldingPosition:
                    {
                        if (this.paperDots.Contains(new Point(x, y)) ||
                            this.paperDots.Contains(new Point(x, foldingPosition - (y - foldingPosition))))
                            newDots.Add(new Point(x, y));
                        break;
                    }
                }
            }
        }

        this.paperDots = newDots;
    }

    /// <summary>
    /// Gets the initial dots and folding instructions from the puzzle input.
    /// </summary>
    /// <returns>Initial dots and folding instructions.</returns>
    private void FillInTheDotsAndInstructions()
    {
        var inputSections = this.InputContents
            .Replace("\r", "")
            .Split("\n\n", StringSplitOptions.TrimEntries)
            .ToList();

        // Fill in the paper dots.
        foreach (var line in inputSections[0].Split('\n', StringSplitOptions.TrimEntries))
        {
            var coordinates = line.Split(',');

            this.paperDots.Add(new Point(int.Parse(coordinates[0]), int.Parse(coordinates[1])));
        }

        // Fill in the folding instructions.
        foreach (var line in inputSections[1].Split('\n', StringSplitOptions.TrimEntries))
        {
            this.foldingInstructions.Add(line.Replace("fold along ", ""));
        }
    }

    /// <summary>
    /// Print the paper dots.
    /// </summary>
    private void PrintTheDots()
    {
        for (var y = 0; y < this.paperHeight; y++)
        {
            for (var x = 0; x < this.paperWidth; x++)
            {
                var isDot = this.paperDots.Contains(new Point(x, y));

                Console.Write(isDot ? "#" : " ");
            }

            Console.WriteLine();
        }
    }
}