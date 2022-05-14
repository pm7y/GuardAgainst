using System;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace GuardAgainstLib.Test;

public class TestArgumentBeingNullOrOutOfRange
{
    [Fact]
    public void WhenArgumentIsEqualToMaximum_ShouldNotThrow()
    {
        const string? myArgument = "D";
        var result = Should.NotThrow(() => GuardAgainst.ArgumentBeingNullOrOutOfRange(myArgument, "B", "D"));
        Assert.NotNull(result);
        Assert.Equal(myArgument, result);
    }

    [Fact]
    public void WhenArgumentIsEqualToMinimum_ShouldNotThrow()
    {
        const string? myArgument = "B";
        var result = Should.NotThrow(() => GuardAgainst.ArgumentBeingNullOrOutOfRange(myArgument, "B", "D"));
        Assert.NotNull(result);
        Assert.Equal(myArgument, result);
    }

    [Fact]
    public void WhenArgumentIsGreaterThanMaximum_ShouldThrowArgumentOutOfRangeException()
    {
        var myArgument = "E";
        var ex = Should.Throw<ArgumentOutOfRangeException>(() =>
        {
            GuardAgainst.ArgumentBeingNullOrOutOfRange(myArgument, "B", "D");
        });

        ex.ParamName.ShouldBe(nameof(myArgument));
    }

    [Fact]
    public void WhenArgumentIsInRange_ShouldNotThrow()
    {
        const string? myArgument = "C";
        var result = Should.NotThrow(() => GuardAgainst.ArgumentBeingNullOrOutOfRange(myArgument, "B", "D"));
        Assert.NotNull(result);
        Assert.Equal(myArgument, result);
    }

    [Fact]
    public void WhenArgumentIsLessThanMinimum_ShouldThrowArgumentOutOfRangeException()
    {
        var myArgument = "A";
        var ex = Should.Throw<ArgumentOutOfRangeException>(() =>
        {
            GuardAgainst.ArgumentBeingNullOrOutOfRange(myArgument, "B", "D");
        });

        ex.ParamName.ShouldBe(nameof(myArgument));
    }

    [Fact]
    public void WhenArgumentValueIsNull_ShouldThrowArgumentNullException()
    {
        const string? myArgument = null;
        var ex = Should.Throw<ArgumentNullException>(() =>
            GuardAgainst.ArgumentBeingNullOrOutOfRange(myArgument, "B", "D"));

        ex.ParamName.ShouldBe(nameof(myArgument));
    }

    [Fact]
    public void WhenMaximumValueIsNull_ShouldThrowArgumentNullException()
    {
        var myArgument = "A";
        var ex = Should.Throw<ArgumentOutOfRangeException>(() =>
        {
            GuardAgainst.ArgumentBeingNullOrOutOfRange(myArgument, "B", null);
        });

        ex.ParamName.ShouldBe("myArgument");
    }

    [Fact]
    public void WhenMinimumValueIsNull_ShouldNotThrow()
    {
        const string myArgument = "A";
        var result = Should.NotThrow(() => GuardAgainst.ArgumentBeingNullOrOutOfRange(myArgument, null, "D"));
        Assert.NotNull(result);
        Assert.Equal(myArgument, result);
    }
}
