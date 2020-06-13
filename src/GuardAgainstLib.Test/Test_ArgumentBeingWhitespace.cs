using System;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace GuardAgainstLib.Test
{
    public class TestArgumentBeingWhitespace : TestBase
    {
        public TestArgumentBeingWhitespace(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void WhenArgumentIsNotWhitespace_ShouldNotThrow()
        {
            var myArgument = " blah ";
            object result = null;
            Should.NotThrow(() =>
            {
                result = GuardAgainst.ArgumentBeingWhitespace(myArgument, nameof(myArgument), null);
            });
            Assert.NotNull(result);
            Assert.Equal(myArgument, result);
        }

        [Fact]
        public void WhenArgumentIsNull_ShouldNotThrowArgumentNullException()
        {
            var myArgument= default(string);
            object result = null;
            Should.NotThrow(() =>
            {
                result = GuardAgainst.ArgumentBeingWhitespace(myArgument, nameof(myArgument), null);
            });
            Assert.Equal(myArgument, result);
        }

        [Fact]
        public void WhenArgumentIsWhitespace_ShouldThrowArgumentException()
        {
            var myArgument = "  ";
            var ex = Should.Throw<ArgumentException>(() =>
            {
                GuardAgainst.ArgumentBeingWhitespace(myArgument, nameof(myArgument), null);
            });

            ex.ParamName.ShouldBe(nameof(myArgument));
        }
    }
}
