using System;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace GuardAgainstLib.Test;

public class TestArgumentBeingGreaterThanMaximum
{
    [Fact]
    public void WhenArgumentIsEqualToMaximum_ShouldNotThrow()
    {
        const string myArgument = "A";
        var result = Should.NotThrow(() => GuardAgainst.ArgumentBeingGreaterThanMaximum(myArgument, "A"));
        Assert.NotNull(result);
        Assert.Equal(myArgument, result);
    }

    [Fact]
    public void WhenArgumentIsGreaterThanMaximum_ShouldThrowArgumentOutOfRangeException()
    {
        var myArgument = "B";
        var ex = Should.Throw<ArgumentOutOfRangeException>(() =>
            GuardAgainst.ArgumentBeingGreaterThanMaximum(myArgument, "A"));

        ex.ParamName.ShouldBe(nameof(myArgument));
    }

    [Fact]
    public void WhenArgumentIsLessThanMaximum_ShouldNotThrow()
    {
        const string myArgument = "A";
        var result = Should.NotThrow(() => GuardAgainst.ArgumentBeingGreaterThanMaximum(myArgument, "B"));
        Assert.NotNull(result);
        Assert.Equal(myArgument, result);
    }

    [Fact]
    public void WhenArgumentIsNull_ShouldNotThrow()
    {
        const string? myArgument = null;

        var result = Should.NotThrow(() => GuardAgainst.ArgumentBeingGreaterThanMaximum(myArgument, "B"));
        Assert.Equal(myArgument, result);
    }

    [Fact]
    public void WhenMaximumValueIsNull_ShouldThrowArgumentOutOfRangeException()
    {
        var myArgument = "A";
        var ex = Should.Throw<ArgumentOutOfRangeException>(() =>
        {
            GuardAgainst.ArgumentBeingGreaterThanMaximum(myArgument, null);
        });

        ex.ParamName.ShouldBe("myArgument");
    }
}
