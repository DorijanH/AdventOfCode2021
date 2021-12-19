using AdventOfCode2021.Days;
using Xunit;

namespace AdventOfCode2021.Tests.Days;

/// <summary>
/// Advent day 14 tests class.
/// </summary>
public class Day14Tests : TestBase
{
    /// <summary>
    /// Advent day 14 tests class constructor.
    /// </summary>
    public Day14Tests() : base(new Day14(true))
    {
    }

    /// <summary>
    /// Tests that the result of the first part of the puzzle is the same as the provided example's result.
    /// </summary>
    [Fact]
    protected override void FirstPart()
    {
        Assert.Equal("1588", this.AdventDay.SolveFirstPart());
    }

    /// <summary>
    /// Tests that the result of the second part of the puzzle is the same as the provided example's result.
    /// </summary>
    [Fact]
    protected override void SecondPart()
    {
        Assert.Equal("2188189693529", this.AdventDay.SolveSecondPart());
    }
}