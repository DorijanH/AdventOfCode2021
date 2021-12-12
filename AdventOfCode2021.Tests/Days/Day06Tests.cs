using AdventOfCode2021.Days;
using Xunit;

namespace AdventOfCode2021.Tests.Days;

/// <summary>
/// Advent day 6 tests class.
/// </summary>
public class Day06Tests : TestBase
{
    /// <summary>
    /// Advent day 6 tests class constructor.
    /// </summary>
    public Day06Tests() : base(new Day06(true))
    {
    }

    /// <summary>
    /// Tests that the result of the first part of the puzzle is the same as the provided example's result.
    /// </summary>
    [Fact]
    protected override void FirstPart()
    {
        Assert.Equal("5934", this.AdventDay.SolveFirstPart());
    }

    /// <summary>
    /// Tests that the result of the second part of the puzzle is the same as the provided example's result.
    /// </summary>
    [Fact]
    protected override void SecondPart()
    {
        Assert.Equal("26984457539", this.AdventDay.SolveSecondPart());
    }
}