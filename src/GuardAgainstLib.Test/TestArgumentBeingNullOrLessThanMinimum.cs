using System;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace GuardAgainstLib.Test;

public class TestArgumentBeingNullOrLessThanMinimum
{
    [Fact]
    public void WhenArgumentIsEqualToMinimum_ShouldNotThrow()
    {
        var myArgument = "A";
        var result = Should.NotThrow(() => GuardAgainst.ArgumentBeingNullOrLessThanMinimum(myArgument, "A"));
        Assert.NotNull(result);
        Assert.Equal(myArgument, result);
    }

    [Fact]
    public void WhenArgumentIsGreaterThanMinimum_ShouldNotThrow()
    {
        const string myArgument = "B";
        var result = Should.NotThrow(() => GuardAgainst.ArgumentBeingNullOrLessThanMinimum(myArgument, "A"));
        Assert.NotNull(result);
        Assert.Equal(myArgument, result);
    }

    [Fact]
    public void WhenArgumentIsLessThanMinimum_ShouldThrowArgumentOutOfRangeException()
    {
        var myArgument = "A";
        var ex = Should.Throw<ArgumentOutOfRangeException>(() =>
        {
            GuardAgainst.ArgumentBeingNullOrLessThanMinimum(myArgument, "B");
        });

        ex.ParamName.ShouldBe(nameof(myArgument));
    }

    [Fact]
    public void WhenArgumentIsNull_ShouldThrowArgumentNullException()
    {
        const string? myArgument = null;
        var ex = Should.Throw<ArgumentNullException>(() =>
            GuardAgainst.ArgumentBeingNullOrLessThanMinimum(myArgument, "B"));

        ex.ParamName.ShouldBe(nameof(myArgument));
    }

    [Fact]
    public void WhenMinimumValueIsNull_ShouldNotThrow()
    {
        var myArgument = "A";

        var result = Should.NotThrow(() =>
            GuardAgainst.ArgumentBeingNullOrLessThanMinimum(myArgument, null));

        Assert.NotNull(result);
        Assert.Equal(myArgument, result);
    }
}
