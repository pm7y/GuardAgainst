using System;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace GuardAgainstLib.Test;

public class TestArgumentBeingEmptyString
{
    [Fact]
    public void WhenArgumentIsEmptyString_ShouldThrowArgumentException()
    {
        var myArgument = "";
        var ex = Should.Throw<ArgumentException>(() =>
        {
            GuardAgainst.ArgumentBeingEmpty(myArgument);
        });

        ex.ParamName.ShouldBe(nameof(myArgument));
    }

    [Fact]
    public void WhenArgumentIsNotNullOrEmptyString_ShouldNotThrow()
    {
        const string myArgument = " blah ";
        var result = Should.NotThrow(() => GuardAgainst.ArgumentBeingEmpty(myArgument));
        Assert.NotNull(result);
        Assert.Equal(myArgument, result);
    }

    [Fact]
    public void WhenArgumentIsNullString_ShouldNotThrow()
    {
        const string? myArgument = null;
        var result = Should.NotThrow(() => GuardAgainst.ArgumentBeingEmpty(myArgument));
        Assert.Equal(myArgument, result);
    }
}
