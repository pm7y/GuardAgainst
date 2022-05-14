using System;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace GuardAgainstLib.Test;

public class TestArgumentBeingNullOrEmptyString
{
    [Fact]
    public void WhenArgumentIsEmpty_ShouldThrowArgumentException()
    {
        var myArgument = "";
        var ex = Should.Throw<ArgumentException>(() =>
        {
            GuardAgainst.ArgumentBeingNullOrEmpty(myArgument);
        });

        ex.ParamName.ShouldBe(nameof(myArgument));
    }

    [Fact]
    public void WhenArgumentIsNotNullOrEmpty_ShouldNotThrow()
    {
        const string? myArgument = " blah ";
        var result = Should.NotThrow(() => GuardAgainst.ArgumentBeingNullOrEmpty(myArgument));
        Assert.NotNull(result);
        Assert.Equal(myArgument, result);
    }

    [Fact]
    public void WhenArgumentIsNull_ShouldThrowArgumentNullException()
    {
        const string? myArgument = null;
        var ex = Should.Throw<ArgumentNullException>(() => GuardAgainst.ArgumentBeingNullOrEmpty(myArgument));

        ex.ParamName.ShouldBe(nameof(myArgument));
    }
}
