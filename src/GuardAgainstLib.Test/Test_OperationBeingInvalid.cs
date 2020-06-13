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
            var myArgument = false;
            object result = null;
            Should.NotThrow(() =>
            {
                result = GuardAgainst.OperationBeingInvalid(myArgument, null);
            });
            Assert.NotNull(result);
            Assert.Equal(myArgument, result);
        }

        [Fact]
        public void WhenArgumentIsTrue_ShouldThrowArgumentException()
        {
            var myArgument = true;
            var ex = Should.Throw<InvalidOperationException>(() =>
            {
                GuardAgainst.OperationBeingInvalid(myArgument, null);
            });
        }
    }
}
