using System;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace GuardAgainstLib.Test;

public class TestArgumentBeingOutOfRangeForValueType
{
    [Fact]
    public void WhenArgumentIsEqualToMaximum_ShouldNotThrow()
    {
        const int myArgument = 4;
        var result = Should.NotThrow(() => GuardAgainst.ArgumentBeingOutOfRange(myArgument, 2, 4));
        Assert.Equal(myArgument, result);
    }

    [Fact]
    public void WhenArgumentIsEqualToMinimum_ShouldNotThrow()
    {
        const int myArgument = 2;
        var result = Should.NotThrow(() => GuardAgainst.ArgumentBeingOutOfRange(myArgument, 2, 4));
        Assert.Equal(myArgument, result);
    }

    [Fact]
    public void WhenArgumentIsGreaterThanMaximum_ShouldThrowArgumentOutOfRangeException()
    {
        const int myArgument = 5;
        var ex = Should.Throw<ArgumentOutOfRangeException>(() =>
            GuardAgainst.ArgumentBeingOutOfRange(myArgument, 2, 4));

        ex.ParamName.ShouldBe(nameof(myArgument));
    }

    [Fact]
    public void WhenArgumentIsInRange_ShouldNotThrow()
    {
        const int myArgument = 3;
        var result = Should.NotThrow(() => GuardAgainst.ArgumentBeingOutOfRange(myArgument, 2, 4));
        Assert.Equal(myArgument, result);
    }

    [Fact]
    public void WhenArgumentIsLessThanMinimum_ShouldThrowArgumentOutOfRangeException()
    {
        const int myArgument = 1;
        var ex = Should.Throw<ArgumentOutOfRangeException>(() =>
            GuardAgainst.ArgumentBeingOutOfRange(myArgument, 2, 4));

        ex.ParamName.ShouldBe(nameof(myArgument));
    }
}
