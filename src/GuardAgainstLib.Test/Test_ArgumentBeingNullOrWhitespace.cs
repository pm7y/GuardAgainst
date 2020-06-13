using System;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace GuardAgainstLib.Test
{
    public class TestArgumentBeingNullOrWhitespace : TestBase
    {
        public TestArgumentBeingNullOrWhitespace(ITestOutputHelper output) : base(output)
        {
        }
        
        [Fact]
        public void WhenArgumentIsNotNullOrWhitespace_ShouldNotThrow()
        {
            var myArgument = " blah ";
            object result = null;
            Should.NotThrow(() =>
            {
                result = GuardAgainst.ArgumentBeingNullOrWhitespace(myArgument, nameof(myArgument), null);
            });
            Assert.NotNull(result);
            Assert.Equal(myArgument, result);
        }

        [Fact]
        public void WhenArgumentIsNull_ShouldThrowArgumentNullException()
        {
            var myArgument= default(string);
            var ex = Should.Throw<ArgumentNullException>(() =>
            {
                GuardAgainst.ArgumentBeingNullOrWhitespace(myArgument, nameof(myArgument), null);
            });

            ex.ParamName.ShouldBe(nameof(myArgument));
        }

        [Fact]
        public void WhenArgumentIsWhitespace_ShouldThrowArgumentException()
        {
            var myArgument = "  ";
            var ex = Should.Throw<ArgumentException>(() =>
            {
                GuardAgainst.ArgumentBeingNullOrWhitespace(myArgument, nameof(myArgument), null);
            });

            ex.ParamName.ShouldBe(nameof(myArgument));
        }
    }
}
