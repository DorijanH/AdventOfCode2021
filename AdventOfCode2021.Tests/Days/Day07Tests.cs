﻿using AdventOfCode2021.Days;
using Xunit;

namespace AdventOfCode2021.Tests.Days;

/// <summary>
/// Advent day 7 tests class.
/// </summary>
public class Day07Tests : TestBase
{
    /// <summary>
    /// Advent day 7 tests class constructor.
    /// </summary>
    public Day07Tests() : base(new Day07(true))
    {
    }

    /// <summary>
    /// Tests that the result of the first part of the puzzle is the same as the provided example's result.
    /// </summary>
    [Fact]
    protected override void FirstPart()
    {
        Assert.Equal("37", this.AdventDay.SolveFirstPart());
    }

    /// <summary>
    /// Tests that the result of the second part of the puzzle is the same as the provided example's result.
    /// </summary>
    [Fact]
    protected override void SecondPart()
    {
        Assert.Equal("168", this.AdventDay.SolveSecondPart());
    }
}