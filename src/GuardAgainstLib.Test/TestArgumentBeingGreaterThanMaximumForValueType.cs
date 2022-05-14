using System;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace GuardAgainstLib.Test;

public class TestArgumentBeingGreaterThanMaximumForValueType
{
    [Fact]
    public void WhenArgumentIsEqualToMaximum_ShouldNotThrow()
    {
        const int myArgument = 1;
        var result = Should.NotThrow(() => GuardAgainst.ArgumentBeingGreaterThanMaximum(myArgument, 2));
        Assert.Equal(myArgument, result);
    }

    [Fact]
    public void WhenArgumentIsGreaterThanMaximum_ShouldThrowArgumentOutOfRangeException()
    {
        var myArgument = 2;
        var ex = Should.Throw<ArgumentOutOfRangeException>(() =>
        {
            GuardAgainst.ArgumentBeingGreaterThanMaximum(myArgument, 1);
        });

        ex.ParamName.ShouldBe(nameof(myArgument));
    }

    [Fact]
    public void WhenArgumentIsLessThanMaximum_ShouldNotThrow()
    {
        const int myArgument = 1;
        var result = Should.NotThrow(() => GuardAgainst.ArgumentBeingGreaterThanMaximum(myArgument, 2));
        Assert.Equal(myArgument, result);
    }
}
