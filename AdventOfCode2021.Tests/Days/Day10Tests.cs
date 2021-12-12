using AdventOfCode2021.Days;
using Xunit;

namespace AdventOfCode2021.Tests.Days;

/// <summary>
/// Advent day 10 tests class.
/// </summary>
public class Day10Tests : TestBase
{
    /// <summary>
    /// Advent day 10 tests class constructor.
    /// </summary>
    public Day10Tests() : base(new Day10(true))
    {
    }

    /// <summary>
    /// Tests that the result of the first part of the puzzle is the same as the provided example's result.
    /// </summary>
    [Fact]
    protected override void FirstPart()
    {
        Assert.Equal("26397", this.AdventDay.SolveFirstPart());
    }

    /// <summary>
    /// Tests that the result of the second part of the puzzle is the same as the provided example's result.
    /// </summary>
    [Fact]
    protected override void SecondPart()
    {
        Assert.Equal("288957", this.AdventDay.SolveSecondPart());
    }
}