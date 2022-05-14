using System;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace GuardAgainstLib.Test;

public class TestArgumentBeingNullOrGreaterThanMaximum
{
    [Fact]
    public void WhenArgumentIsEqualToMaximum_ShouldNotThrow()
    {
        const string? myArgument = "A";
        var result = Should.NotThrow(() => GuardAgainst.ArgumentBeingNullOrGreaterThanMaximum(myArgument, "A"));
        Assert.NotNull(result);
        Assert.Equal(myArgument, result);
    }

    [Fact]
    public void WhenArgumentIsGreaterThanMaximum_ShouldThrowArgumentOutOfRangeException()
    {
        var myArgument = "B";
        var ex = Should.Throw<ArgumentOutOfRangeException>(() =>
        {
            GuardAgainst.ArgumentBeingNullOrGreaterThanMaximum(myArgument, "A");
        });

        ex.ParamName.ShouldBe(nameof(myArgument));
    }

    [Fact]
    public void WhenArgumentIsLessThanMaximum_ShouldNotThrow()
    {
        const string? myArgument = "A";
        var result = Should.NotThrow(() => GuardAgainst.ArgumentBeingNullOrGreaterThanMaximum(myArgument, "B"));
        Assert.NotNull(result);
        Assert.Equal(myArgument, result);
    }

    [Fact]
    public void WhenArgumentIsNull_ShouldThrowArgumentNullException()
    {
        const string? myArgument = null;
        var ex = Should.Throw<ArgumentNullException>(() =>
        {
            GuardAgainst.ArgumentBeingNullOrGreaterThanMaximum(myArgument, "B");
        });

        ex.ParamName.ShouldBe(nameof(myArgument));
    }

    [Fact]
    public void WhenMaximumValueIsNull_ShouldThrowArgumentNullException()
    {
        var myArgument = "A";
        var ex = Should.Throw<ArgumentOutOfRangeException>(() =>
        {
            GuardAgainst.ArgumentBeingNullOrGreaterThanMaximum(myArgument, null);
        });

        ex.ParamName.ShouldBe("myArgument");
    }
}
