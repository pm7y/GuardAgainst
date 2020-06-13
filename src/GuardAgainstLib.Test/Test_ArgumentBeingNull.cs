using System;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace GuardAgainstLib.Test
{
    public class TestArgumentBeingNull : TestBase
    {
        public TestArgumentBeingNull(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void WhenArgumentIsNotNull_ShouldNotThrow()
        {
            var myArgument = "Hello, World!";
            object result = null;
            Should.NotThrow(() =>
            {
                result = GuardAgainst.ArgumentBeingNull(myArgument, nameof(myArgument), null);
            });
            Assert.NotNull(result);
            Assert.Equal(myArgument, result);
        }

        [Fact]
        public void WhenArgumentIsNull_ShouldThrowArgumentNullException()
        {
            var myArgument= default(object);
            var ex = Should.Throw<ArgumentNullException>(() =>
            {
                GuardAgainst.ArgumentBeingNull(myArgument, nameof(myArgument), null);
            });

            ex.ParamName.ShouldBe(nameof(myArgument));
        }
    }
}
