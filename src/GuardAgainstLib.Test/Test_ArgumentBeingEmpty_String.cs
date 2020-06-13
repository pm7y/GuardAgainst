using System;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace GuardAgainstLib.Test
{
    public class TestArgumentBeingEmptyString : TestBase
    {
        public TestArgumentBeingEmptyString(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void WhenArgumentIsEmptyString_ShouldThrowArgumentException()
        {
            var myArgument = "";
            var ex = Should.Throw<ArgumentException>(() =>
            {
                GuardAgainst.ArgumentBeingEmpty(myArgument, nameof(myArgument), null);
            });

            ex.ParamName.ShouldBe(nameof(myArgument));
        }

        [Fact]
        public void WhenArgumentIsNotNullOrEmptyString_ShouldNotThrow()
        {
            var myArgument = " blah ";
            object result = null;
            Should.NotThrow(() =>
            {
                result = GuardAgainst.ArgumentBeingEmpty(myArgument, nameof(myArgument), null);
            });
            Assert.NotNull(result);
            Assert.Equal(myArgument, result);
        }

        [Fact]
        public void WhenArgumentIsNullString_ShouldNotThrow()
        {
            var myArgument= default(string);
            object result = null;
            Should.NotThrow(() =>
            {
                result = GuardAgainst.ArgumentBeingEmpty(myArgument, nameof(myArgument), null);
            });
            Assert.Equal(myArgument, result);
        }
    }
}
