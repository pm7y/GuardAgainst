using System;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace GuardAgainstLib.Test;

public class TestArgumentBeingEmptyGuid
{
    [Fact]
    public void WhenArgumentIsEmptyGuid_ShouldThrowArgumentException()
    {
        var myArgument = Guid.Empty;
        var ex = Should.Throw<ArgumentException>(() =>
        {
            GuardAgainst.ArgumentBeingEmpty(myArgument);
        });

        ex.ParamName.ShouldBe(nameof(myArgument));
    }

    [Fact]
    public void WhenArgumentIsNotEmptyGuid_ShouldNotThrow()
    {
        var myArgument = new Guid("1e750e0a-f9be-4d31-a78e-590325cb7045");
        var result = Should.NotThrow(() => GuardAgainst.ArgumentBeingEmpty(myArgument));
        Assert.Equal(myArgument, result);
    }
}
