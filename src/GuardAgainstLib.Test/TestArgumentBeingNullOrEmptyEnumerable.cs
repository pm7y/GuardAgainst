using System;
using System.Collections.Generic;
using System.Linq;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace GuardAgainstLib.Test;

public class TestArgumentBeingNullOrEmptyEnumerable
{
    [Fact]
    public void WhenArgumentIsEmpty_ShouldThrowArgumentException()
    {
        var myArgument = Enumerable.Empty<string>();
        var ex = Should.Throw<ArgumentException>(() =>
        {
            GuardAgainst.ArgumentBeingNullOrEmpty(myArgument);
        });

        ex.ParamName.ShouldBe(nameof(myArgument));
    }

    [Fact]
    public void WhenArgumentIsNotNullOrEmpty_ShouldNotThrow()
    {
        var myArgument = new[] {"blah"};
        var result = Should.NotThrow(() => GuardAgainst.ArgumentBeingNullOrEmpty(myArgument));
        Assert.NotNull(result);
        Assert.Equal(myArgument, result);
    }

    [Fact]
    public void WhenArgumentIsNull_ShouldThrowArgumentNullException()
    {
        const IEnumerable<string>? myArgument = null;
        var ex = Should.Throw<ArgumentNullException>(() => GuardAgainst.ArgumentBeingNullOrEmpty(myArgument));

        ex.ParamName.ShouldBe(nameof(myArgument));
    }
}
