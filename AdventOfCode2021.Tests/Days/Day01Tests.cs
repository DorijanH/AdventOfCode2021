using AdventOfCode2021.Days;
using Xunit;

namespace AdventOfCode2021.Tests.Days;

/// <summary>
/// Advent day 1 tests class.
/// </summary>
public class Day01Tests : TestBase
{
    /// <summary>
    /// Advent day 1 tests class constructor.
    /// </summary>
    public Day01Tests() : base(new Day01(true))
    {
    }

    /// <summary>
    /// Tests that the result of the first part of the puzzle is the same as the provided example's result.
    /// </summary>
    [Fact]
    protected override void FirstPart()
    {
        Assert.Equal("7", this.AdventDay.SolveFirstPart());
    }

    /// <summary>
    /// Tests that the result of the second part of the puzzle is the same as the provided example's result.
    /// </summary>
    [Fact]
    protected override void SecondPart()
    {
        Assert.Equal("5", this.AdventDay.SolveSecondPart());
    }
}