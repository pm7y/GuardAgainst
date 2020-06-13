using System;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace GuardAgainstLib.Test
{
    public class TestArgumentBeingUnspecifiedDateTime : TestBase
    {
        public TestArgumentBeingUnspecifiedDateTime(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void WhenArgumentValueIsLocal_ShouldNotThrow()
        {
            var myArgument = DateTime.UtcNow;
            object result = null;
            Should.NotThrow(() =>
            {
                result = GuardAgainst.ArgumentBeingUnspecifiedDateTime(myArgument, nameof(myArgument), null);
            });
            Assert.NotNull(result);
            Assert.Equal(myArgument, result);
        }

        [Fact]
        public void WhenArgumentValueIsUnspecified_ShouldThrowArgumentException()
        {
            var myArgument = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified);
            var ex = Should.Throw<ArgumentException>(() =>
            {
                GuardAgainst.ArgumentBeingUnspecifiedDateTime(myArgument, nameof(myArgument), null);
            });

            ex.ParamName.ShouldBe(nameof(myArgument));
        }

        [Fact]
        public void WhenArgumentValueIsUtc_ShouldNotThrow()
        {
            var myArgument = DateTime.UtcNow;
            object result = null;
            Should.NotThrow(() =>
            {
                result = GuardAgainst.ArgumentBeingUnspecifiedDateTime(myArgument, nameof(myArgument), null);
            });
            Assert.NotNull(result);
            Assert.Equal(myArgument, result);
        }
    }
}
