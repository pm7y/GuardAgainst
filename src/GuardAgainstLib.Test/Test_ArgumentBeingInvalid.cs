using System;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace GuardAgainstLib.Test
{
    public class TestArgumentBeingInvalid : TestBase
    {
        public TestArgumentBeingInvalid(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void WhenArgumentIsFalse_ShouldNotThrow()
        {
            var myArgument = false;
            object result = null;
            Should.NotThrow(() =>
            {
                result = GuardAgainst.ArgumentBeingInvalid(myArgument, nameof(myArgument), null);
            });
            Assert.NotNull(result);
            Assert.Equal(myArgument, result);
        }

        [Fact]
        public void WhenArgumentIsTrue_ShouldThrowArgumentException()
        {
            var myArgument = true;
            var ex = Should.Throw<ArgumentException>(() =>
            {
                GuardAgainst.ArgumentBeingInvalid(myArgument, nameof(myArgument), null);
            });

            ex.ParamName.ShouldBe(nameof(myArgument));
        }
    }
}
