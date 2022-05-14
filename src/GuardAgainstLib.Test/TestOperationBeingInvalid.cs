using System;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace GuardAgainstLib.Test;

public class TestOperationBeingInvalid
{
    [Fact]
    public void WhenArgumentIsFalse_ShouldNotThrow()
    {
        const bool myArgument = false;
        var result = Should.NotThrow(() => GuardAgainst.OperationBeingInvalid(myArgument));
        Assert.Equal(myArgument, result);
    }

    [Fact]
    public void WhenArgumentIsTrue_ShouldThrowArgumentException()
    {
        const bool myArgument = true;
        Should.Throw<InvalidOperationException>(() =>
        {
            GuardAgainst.OperationBeingInvalid(myArgument);
        });
    }
}
