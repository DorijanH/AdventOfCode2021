namespace AdventOfCode2021.Days;

/// <summary>
/// Class representing the advent day 2.
/// </summary>
public class Day2 : AdventDay
{
    private readonly (string command, int value)[] input;

    /// <summary>
    /// Initializes the class representing the advent day 2.
    /// </summary>
    /// <param name="isExample">Should example input be used.</param>
    public Day2(bool isExample = false) : base(2, isExample)
    {
        this.input = this.InputContents
            .Split('\n', StringSplitOptions.RemoveEmptyEntries)
            .Select(line => line.Split(' '))
            .Select(lineParts => (lineParts[0], int.Parse(lineParts[1])))
            .ToArray();
    }

    /// <summary>
    /// Solves the first part of the advent day puzzle.
    /// </summary>
    /// <returns>Puzzle result.</returns>
    public override string SolveFirstPart()
    {
        var xPos = 0;
        var yPos = 0;

        foreach (var (command, value) in this.input)
        {
            switch (command)
            {
                case "forward":
                    xPos += value;
                    break;
                case "down":
                    yPos += value;
                    break;
                case "up":
                    yPos -= value;
                    break;
                default:
                    continue;
            }
        }

        Console.WriteLine($"After all the lines we are at ({xPos}, {yPos})");
        Console.WriteLine($"Multiplication gives back {xPos * yPos}");

        return $"{xPos * yPos}";
    }

    /// <summary>
    /// Solves the second part of the advent day puzzle.
    /// </summary>
    /// <returns>Puzzle result.</returns>
    public override string SolveSecondPart()
    {
        var xPos = 0;
        var yPos = 0;
        var aim = 0;

        foreach (var (command, value) in this.input)
        {
            switch (command)
            {
                case "forward":
                    xPos += value;
                    yPos += aim * value;
                    break;
                case "down":
                    aim += value;
                    break;
                case "up":
                    aim -= value;
                    break;
                default:
                    continue;
            }
        }

        Console.WriteLine($"After all the lines we are at ({xPos}, {yPos})");
        Console.WriteLine($"Multiplication gives back {xPos * yPos}");

        return $"{xPos * yPos}";
    }
}