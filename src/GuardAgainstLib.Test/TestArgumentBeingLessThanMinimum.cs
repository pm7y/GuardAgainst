using System;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace GuardAgainstLib.Test;

public class TestArgumentBeingLessThanMinimum
{
    [Fact]
    public void WhenArgumentIsEqualToMinimum_ShouldNotThrow()
    {
        const string? myArgument = "A";
        var result = Should.NotThrow(() => GuardAgainst.ArgumentBeingLessThanMinimum(myArgument, "A"));
        Assert.NotNull(result);
        Assert.Equal(myArgument, result);
    }

    [Fact]
    public void WhenArgumentIsGreaterThanMinimum_ShouldNotThrow()
    {
        const string? myArgument = "B";
        var result = Should.NotThrow(() => GuardAgainst.ArgumentBeingLessThanMinimum(myArgument, "A"));
        Assert.NotNull(result);
        Assert.Equal(myArgument, result);
    }

    [Fact]
    public void WhenArgumentIsLessThanMinimum_ShouldThrowArgumentOutOfRangeException()
    {
        var myArgument = "A";
        var ex = Should.Throw<ArgumentOutOfRangeException>(() =>
        {
            GuardAgainst.ArgumentBeingLessThanMinimum(myArgument, "B");
        });

        ex.ParamName.ShouldBe(nameof(myArgument));
    }

    [Fact]
    public void WhenArgumentIsNull_ShouldNotThrowException()
    {
        const string? myArgument = null;
        var result = Should.NotThrow(() =>
            GuardAgainst.ArgumentBeingLessThanMinimum(myArgument, "B"));

        Assert.Equal(myArgument, result);
    }

    [Fact]
    public void WhenMinimumValueIsNull_ShouldNotThrow()
    {
        const string? myArgument = "A";
        var result = Should.NotThrow(() => GuardAgainst.ArgumentBeingLessThanMinimum(myArgument, null));
        Assert.Equal(myArgument, result);
    }
}
