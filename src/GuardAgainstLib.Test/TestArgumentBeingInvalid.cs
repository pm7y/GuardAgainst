using System;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace GuardAgainstLib.Test;

public class TestArgumentBeingInvalid
{
    [Fact]
    public void WhenArgumentIsInvalidEnum_ShouldThrowArgumentException()
    {
        const TestEnum myArgument = TestEnum.Invalid;
        var ex = Should.Throw<ArgumentException>(() =>
        {
            GuardAgainst.ArgumentBeingInvalidEnum(myArgument, TestEnum.Invalid);
        });

        ex.ParamName.ShouldBe(nameof(myArgument));
    }


    [Fact]
    public void WhenArgumentIsValidEnum_ShouldNotThrow()
    {
        const TestEnum myArgument = TestEnum.Ok;
        Should.NotThrow(() =>
        {
            GuardAgainst.ArgumentBeingInvalidEnum(myArgument, TestEnum.Invalid);
        });
    }


    private enum TestEnum : long
    {
        Invalid = 0,
        Ok = 1
    }
}
