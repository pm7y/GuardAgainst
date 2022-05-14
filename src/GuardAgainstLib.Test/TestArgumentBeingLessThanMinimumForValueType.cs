using System;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace GuardAgainstLib.Test;

public class TestArgumentBeingLessThanMinimumForValueType
{
    [Fact]
    public void WhenArgumentIsEqualToMinimum_ShouldNotThrow()
    {
        var myArgument = 1;
        var result = Should.NotThrow(() => GuardAgainst.ArgumentBeingLessThanMinimum(myArgument, myArgument));
        Assert.Equal(myArgument, result);
    }

    [Fact]
    public void WhenArgumentIsGreaterThanMinimum_ShouldNotThrow()
    {
        var myArgument = 2;
        var result = Should.NotThrow(() => GuardAgainst.ArgumentBeingLessThanMinimum(myArgument, 1));
        Assert.NotNull(result);
        Assert.Equal(myArgument, result);
    }

    [Fact]
    public void WhenArgumentIsLessThanMinimum_ShouldThrowArgumentOutOfRangeException()
    {
        var myArgument = 1;
        var ex = Should.Throw<ArgumentOutOfRangeException>(() =>
        {
            GuardAgainst.ArgumentBeingLessThanMinimum(myArgument, 2);
        });

        ex.ParamName.ShouldBe(nameof(myArgument));
    }
}
