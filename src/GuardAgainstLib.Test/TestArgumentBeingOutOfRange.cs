using System;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace GuardAgainstLib.Test;

public class TestArgumentBeingOutOfRange
{
    [Fact]
    public void WhenArgumentIsEqualToMaximum_ShouldNotThrow()
    {
        const string myArgument = "D";
        var result = Should.NotThrow(() => GuardAgainst.ArgumentBeingOutOfRange(myArgument, "B", "D"));
        Assert.NotNull(result);
        Assert.Equal(myArgument, result);
    }

    [Fact]
    public void WhenArgumentIsEqualToMinimum_ShouldNotThrow()
    {
        const string myArgument = "B";
        var result = Should.NotThrow(() => GuardAgainst.ArgumentBeingOutOfRange(myArgument, "B", "D"));
        Assert.NotNull(result);
        Assert.Equal(myArgument, result);
    }

    [Fact]
    public void WhenArgumentIsGreaterThanMaximum_ShouldThrowArgumentOutOfRangeException()
    {
        const string myArgument = "E";
        var ex = Should.Throw<ArgumentOutOfRangeException>(() =>
            GuardAgainst.ArgumentBeingOutOfRange(myArgument, "B", "D"));

        ex.ParamName.ShouldBe(nameof(myArgument));
    }

    [Fact]
    public void WhenArgumentIsInRange_ShouldNotThrow()
    {
        const string myArgument = "C";
        var result = Should.NotThrow(() => GuardAgainst.ArgumentBeingOutOfRange(myArgument, "B", "D"));
        Assert.NotNull(result);
        Assert.Equal(myArgument, result);
    }

    [Fact]
    public void WhenArgumentIsLessThanMinimum_ShouldThrowArgumentOutOfRangeException()
    {
        const string? myArgument = "A";
        var ex = Should.Throw<ArgumentOutOfRangeException>(() =>
            GuardAgainst.ArgumentBeingOutOfRange(myArgument, "B", "D"));

        ex.ParamName.ShouldBe(nameof(myArgument));
    }

    [Fact]
    public void WhenArgumentValueIsNull_ShouldNotThrow()
    {
        const string? myArgument = null;
        var result = Should.NotThrow(() => GuardAgainst.ArgumentBeingOutOfRange(myArgument, "B", "D"));
        Assert.Equal(myArgument, result);
    }

    [Fact]
    public void WhenMaximumValueIsNull_ShouldThrowArgumentNullException()
    {
        const string myArgument = "A";
        var ex = Should.Throw<ArgumentOutOfRangeException>(() =>
            GuardAgainst.ArgumentBeingOutOfRange(myArgument, "B", null));

        ex.ParamName.ShouldBe("myArgument");
    }

    [Fact]
    public void WhenMinimumValueIsNull_ShouldNotThrow()
    {
        const string myArgument = "A";
        var result = Should.NotThrow(() => GuardAgainst.ArgumentBeingOutOfRange(myArgument, null, "D"));
        Assert.NotNull(result);
        Assert.Equal(myArgument, result);
    }
}
