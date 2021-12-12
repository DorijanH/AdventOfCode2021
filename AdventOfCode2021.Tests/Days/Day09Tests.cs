using AdventOfCode2021.Days;
using Xunit;

namespace AdventOfCode2021.Tests.Days;

/// <summary>
/// Advent day 9 tests class.
/// </summary>
public class Day09Tests : TestBase
{
    /// <summary>
    /// Advent day 9 tests class constructor.
    /// </summary>
    public Day09Tests() : base(new Day09(true))
    {
    }

    /// <summary>
    /// Tests that the result of the first part of the puzzle is the same as the provided example's result.
    /// </summary>
    [Fact]
    protected override void FirstPart()
    {
        Assert.Equal("15", this.AdventDay.SolveFirstPart());
    }

    /// <summary>
    /// Tests that the result of the second part of the puzzle is the same as the provided example's result.
    /// </summary>
    [Fact]
    protected override void SecondPart()
    {
        Assert.Equal("1134", this.AdventDay.SolveSecondPart());
    }
}