using AdventOfCode2021.Days;
using Xunit;

namespace AdventOfCode2021.Tests.Days;

/// <summary>
/// Advent day 8 tests class.
/// </summary>
public class Day8Tests : TestBase
{
    /// <summary>
    /// Advent day 8 tests class constructor.
    /// </summary>
    public Day8Tests() : base(new Day8(true))
    {
    }

    /// <summary>
    /// Tests that the result of the first part of the puzzle is the same as the provided example's result.
    /// </summary>
    [Fact]
    protected override void FirstPart()
    {
        Assert.Equal("26", this.AdventDay.SolveFirstPart());
    }

    /// <summary>
    /// Tests that the result of the second part of the puzzle is the same as the provided example's result.
    /// </summary>
    [Fact]
    protected override void SecondPart()
    {
        Assert.Equal("61229", this.AdventDay.SolveSecondPart());
    }
}