namespace AdventOfCode2021.Days;

/// <summary>
/// Class representing the advent day 6.
/// </summary>
public class Day06 : AdventDay
{
    private readonly int[] inputs;

    /// <summary>
    /// Initializes the class representing the advent day 6.
    /// </summary>
    /// <param name="isExample">Should example input be used.</param>
    public Day06(bool isExample = false) : base(6, isExample)
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
        const int daysToCount = 80;
        var timers = this.InitialTimers();

        Console.WriteLine($"Initial state: {timers.Sum(t => t.Value)}");

        for (var day = 1; day <= daysToCount; day++)
        {
            timers = SimulateDay(timers);

            Console.WriteLine($"After \t{day} day: {timers.Sum(t => t.Value)}");
        }

        return $"{timers.Sum(t => t.Value)}";
    }

    /// <summary>
    /// Solves the second part of the advent day puzzle.
    /// </summary>
    /// <returns>Puzzle result.</returns>
    public override string SolveSecondPart()
    {
        const int daysToCount = 256;
        var timers = this.InitialTimers();

        Console.WriteLine($"Initial state: {timers.Sum(t => t.Value)}");

        for (var day = 1; day <= daysToCount; day++)
        {
            timers = SimulateDay(timers);

            Console.WriteLine($"After \t{day} day: {timers.Sum(t => t.Value)}");
        }

        return $"{timers.Sum(t => t.Value)}";
    }

    /// <summary>
    /// Simulates the day and forwards the lanternfishes' timer.
    /// </summary>
    /// <param name="timers">Current timers.</param>
    /// <returns>Updated timers.</returns>
    private static Dictionary<int, long> SimulateDay(Dictionary<int, long> timers)
    {
        var newTimers = new Dictionary<int, long>
        {
            { 0, 0 }, { 1, 0 }, { 2, 0 }, { 3, 0 }, { 4, 0 }, { 5, 0 }, { 6, 0 }, { 7, 0 }, { 8, 0 }
        };

        foreach (var timer in timers.Keys)
        {
            if (timer == 0)
            {
                newTimers[8] += timers[timer];
                newTimers[6] += timers[timer];
            }
            else
            {
                newTimers[timer - 1] += timers[timer];
            }
        }

        return newTimers;
    }

    /// <summary>
    /// Gets the initial timers from the puzzle input.
    /// </summary>
    /// <returns>Initial puzzle input's timers.</returns>
    private Dictionary<int, long> InitialTimers()
    {
        var initialTimers = new Dictionary<int, long>
        {
            { 0, 0 }, { 1, 0 }, { 2, 0 }, { 3, 0 }, { 4, 0 }, { 5, 0 }, { 6, 0 }, { 7, 0 }, { 8, 0 }
        };

        foreach (var timer in this.inputs)
        {
            initialTimers[timer]++;
        }

        return initialTimers;
    }
}