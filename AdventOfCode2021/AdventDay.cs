namespace AdventOfCode2021;

/// <summary>
/// Abstract class representing the advent day.
/// </summary>
public abstract class AdventDay
{
    /// <summary>
    /// Flag indicating should the example input be used.
    /// </summary>
    public bool IsExample { get; set; }

    /// <summary>
    /// Number representing the day of the month.
    /// </summary>
    public int Day { get; set; }

    /// <summary>
    /// Day input text file contents.
    /// </summary>
    public string InputContents =>
        File.ReadAllText($"../../../../AdventOfCode2021/Inputs/Day{Day}{(this.IsExample ? "Example" : "")}.txt");

    /// <summary>
    /// Initializes the certain advent day.
    /// </summary>
    /// <param name="day">Number representing the day of the month.</param>
    /// <param name="isExample">Should example input be used flag.</param>
    protected AdventDay(int day, bool isExample)
    {
        this.Day = day;
        this.IsExample = isExample;
    }

    /// <summary>
    /// Solves the advent day.
    /// </summary>
    public void Solve()
    {
        Console.WriteLine("FIRST PART:");
        Console.WriteLine(this.SolveFirstPart());

        Console.WriteLine();

        Console.WriteLine("SECOND PART:");
        Console.WriteLine(this.SolveSecondPart());
    }

    /// <summary>
    /// Solves the first part of the advent day puzzle.
    /// </summary>
    /// <returns>Result for the first part of the puzzle.</returns>
    public abstract string SolveFirstPart();

    /// <summary>
    /// Solves the second part of the advent day puzzle.
    /// </summary>
    /// <returns>Result for the second part of the puzzle.</returns>
    public abstract string SolveSecondPart();
}