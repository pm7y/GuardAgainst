using System;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace GuardAgainstLib.Test;

public class TestArgumentBeingNullOrWhitespace
{
    [Fact]
    public void WhenArgumentIsNotNullOrWhitespace_ShouldNotThrow()
    {
        const string? myArgument = " blah ";
        var result = Should.NotThrow(() => GuardAgainst.ArgumentBeingNullOrWhitespace(myArgument));
        Assert.NotNull(result);
        Assert.Equal(myArgument, result);
    }

    [Fact]
    public void WhenArgumentIsNull_ShouldThrowArgumentNullException()
    {
        const string? myArgument = null;
        var ex = Should.Throw<ArgumentNullException>(() => GuardAgainst.ArgumentBeingNullOrWhitespace(myArgument));

        ex.ParamName.ShouldBe(nameof(myArgument));
    }

    [Fact]
    public void WhenArgumentIsWhitespace_ShouldThrowArgumentException()
    {
        var myArgument = "  ";
        var ex = Should.Throw<ArgumentException>(() =>
        {
            GuardAgainst.ArgumentBeingNullOrWhitespace(myArgument);
        });

        ex.ParamName.ShouldBe(nameof(myArgument));
    }
}
