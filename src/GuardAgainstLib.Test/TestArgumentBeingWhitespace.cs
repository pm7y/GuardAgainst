using System;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace GuardAgainstLib.Test;

public class TestArgumentBeingWhitespace
{
    [Fact]
    public void WhenArgumentIsNotWhitespace_ShouldNotThrow()
    {
        const string myArgument = " blah ";
        var result = Should.NotThrow(() => GuardAgainst.ArgumentBeingWhitespace(myArgument));
        Assert.NotNull(result);
        Assert.Equal(myArgument, result);
    }

    [Fact]
    public void WhenArgumentIsNull_ShouldNotThrowArgumentNullException()
    {
        const string? myArgument = null;
        var result = Should.NotThrow(() => GuardAgainst.ArgumentBeingWhitespace(myArgument));
        Assert.Equal(myArgument, result);
    }

    [Fact]
    public void WhenArgumentIsWhitespace_ShouldThrowArgumentException()
    {
        const string myArgument = "  ";
        var ex = Should.Throw<ArgumentException>(() => GuardAgainst.ArgumentBeingWhitespace(myArgument));

        ex.ParamName.ShouldBe(nameof(myArgument));
    }
}
