using System;
using System.Linq;
using Shouldly;
using Xunit;

namespace GuardAgainstLib.Test;

public class TestArgumentBeingEmptyEnumerable
{
    [Fact]
    public void WhenArgumentIsEmptyEnumerable_ShouldThrowArgumentException()
    {
        var myArgument = Enumerable.Empty<int>();
        var ex = Should.Throw<ArgumentException>(() =>
        {
            GuardAgainst.ArgumentBeingEmpty(myArgument);
        });

        ex.ParamName.ShouldBe(nameof(myArgument));
    }

    [Fact]
    public void WhenArgumentIsNotNullOrEmptyString_ShouldNotThrow()
    {
        var myArgument = new[] {1};

        var result = Should.NotThrow(() => GuardAgainst.ArgumentBeingEmpty(myArgument));
        Assert.NotNull(result);
        Assert.Equal(myArgument, result);
    }

    [Fact]
    public void WhenArgumentIsNullEnumerable_ShouldNotThrow()
    {
        const int[]? myArgument = null;
        var result = Should.NotThrow(() => GuardAgainst.ArgumentBeingEmpty(myArgument));
        Assert.True(myArgument == result);
    }
}
