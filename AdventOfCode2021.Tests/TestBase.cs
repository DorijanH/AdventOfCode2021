namespace AdventOfCode2021.Tests;

/// <summary>
/// Test base class.
/// </summary>
public abstract class TestBase
{
    /// <summary>
    /// Specific <see cref="AdventDay"/> instance.
    /// </summary>
    protected AdventDay AdventDay;

    /// <summary>
    /// Test base class constructor.
    /// </summary>
    /// <param name="adventDay">Specific <see cref="AdventDay"/> instance.</param>
    protected TestBase(AdventDay adventDay)
    {
        this.AdventDay = adventDay;
    }

    /// <summary>
    /// Method that must be implemented which tests the first part of the puzzle.
    /// </summary>
    protected abstract void FirstPart();

    /// <summary>
    /// Method that must be implemented which tests the second part of the puzzle.
    /// </summary>
    protected abstract void SecondPart();
}