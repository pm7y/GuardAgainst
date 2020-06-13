using System;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace GuardAgainstLib.Test
{
    public class TestArgumentBeingGreaterThanMaximumForValueType : TestBase
    {
        public TestArgumentBeingGreaterThanMaximumForValueType(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void WhenArgumentIsEqualToMaximum_ShouldNotThrow()
        {
            var myArgument = 1;
            object result = null;
            Should.NotThrow(() =>
            {
                result = GuardAgainst.ArgumentBeingGreaterThanMaximum(myArgument, 2, nameof(myArgument), null);
            });
            Assert.NotNull(result);
            Assert.Equal(myArgument, result);
        }

        [Fact]
        public void WhenArgumentIsGreaterThanMaximum_ShouldThrowArgumentOutOfRangeException()
        {
            var myArgument = 2;
            var ex = Should.Throw<ArgumentOutOfRangeException>(() =>
            {
                GuardAgainst.ArgumentBeingGreaterThanMaximum(myArgument, 1, nameof(myArgument), null);
            });

            ex.ParamName.ShouldBe(nameof(myArgument));
        }

        [Fact]
        public void WhenArgumentIsLessThanMaximum_ShouldNotThrow()
        {
            var myArgument = 1;
            object result = null;
            Should.NotThrow(() =>
            {
                result = GuardAgainst.ArgumentBeingGreaterThanMaximum(myArgument, 2, nameof(myArgument), null);
            });
            Assert.Equal(myArgument, result);
        }
    }
}
