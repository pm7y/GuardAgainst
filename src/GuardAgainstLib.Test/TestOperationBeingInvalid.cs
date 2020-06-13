using System;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace GuardAgainstLib.Test
{
    public class TestOperationBeingInvalid : TestBase
    {
        public TestOperationBeingInvalid(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void WhenArgumentIsFalse_ShouldNotThrow()
        {
            const bool myArgument = false;
            object result = null;
            Should.NotThrow(() =>
            {
                result = GuardAgainst.OperationBeingInvalid(myArgument);
            });
            Assert.NotNull(result);
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
}
