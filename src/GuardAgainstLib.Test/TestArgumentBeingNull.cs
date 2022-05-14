using System;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace GuardAgainstLib.Test;

public class TestArgumentBeingNull
{
    [Fact]
    public void WhenObjectArgumentIsNotNull_ShouldNotThrow()
    {
        var myArgument = new object();

        var result = Should.NotThrow(() => GuardAgainst.ArgumentBeingNull(myArgument, msg: "asd"));
        Assert.NotNull(result);
        Assert.Equal(myArgument, result);
    }

    [Fact]
    public void WhenStringArgumentIsNotNull_ShouldNotThrow()
    {
        var myArgument = "asd";

        var result = Should.NotThrow(() => GuardAgainst.ArgumentBeingNull(myArgument));
        Assert.NotNull(result);
        Assert.Equal(myArgument, result);
    }

    [Fact]
    public void WhenArgumentIsNull_ShouldThrowArgumentNullException()
    {
        const object? myArgument = null;
        var ex = Should.Throw<ArgumentNullException>(() =>
        {
            GuardAgainst.ArgumentBeingNull(myArgument);
        });

        ex.ParamName.ShouldBe(nameof(myArgument));
    }
}
