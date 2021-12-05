using AdventOfCode2021.Days;
using Xunit;

namespace AdventOfCode2021.Tests.Days;

/// <summary>
/// Advent day 4 tests class.
/// </summary>
public class Day4Tests : TestBase
{
    /// <summary>
    /// Advent day 4 tests class constructor.
    /// </summary>
    public Day4Tests() : base(new Day4(true))
    {
    }

    /// <summary>
    /// Tests that the result of the first part of the puzzle is the same as the provided example's result.
    /// </summary>
    [Fact]
    protected override void FirstPart()
    {
        Assert.Equal("4512", this.AdventDay.SolveFirstPart());
    }

    /// <summary>
    /// Tests that the result of the second part of the puzzle is the same as the provided example's result.
    /// </summary>
    [Fact]
    protected override void SecondPart()
    {
        Assert.Equal("1924", this.AdventDay.SolveSecondPart());
    }
}