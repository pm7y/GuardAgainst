using System;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace GuardAgainstLib.Test
{
    public class TestArgumentBeingGreaterThanMaximum : TestBase
    {
        public TestArgumentBeingGreaterThanMaximum(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void WhenArgumentIsEqualToMaximum_ShouldNotThrow()
        {
            var myArgument = "A";
            object result = null;
            Should.NotThrow(() =>
            {
                result = GuardAgainst.ArgumentBeingGreaterThanMaximum(myArgument, "A", nameof(myArgument), null);
            });
            Assert.NotNull(result);
            Assert.Equal(myArgument, result);
        }

        [Fact]
        public void WhenArgumentIsGreaterThanMaximum_ShouldThrowArgumentOutOfRangeException()
        {
            var myArgument = "B";
            var ex = Should.Throw<ArgumentOutOfRangeException>(() =>
            {
                GuardAgainst.ArgumentBeingGreaterThanMaximum(myArgument, "A", nameof(myArgument), null);
            });

            ex.ParamName.ShouldBe(nameof(myArgument));
        }
        
        [Fact]
        public void WhenArgumentIsLessThanMaximum_ShouldNotThrow()
        {
            var myArgument = "A";
            object result = null;
            Should.NotThrow(() =>
            {
                result = GuardAgainst.ArgumentBeingGreaterThanMaximum(myArgument, "B", nameof(myArgument), null);
            });
            Assert.NotNull(result);
            Assert.Equal(myArgument, result);
        }

        [Fact]
        public void WhenArgumentIsNull_ShouldNotThrow()
        {
            var myArgument= default(string);
            object result = null;
            Should.NotThrow(() =>
            {
                GuardAgainst.ArgumentBeingGreaterThanMaximum(myArgument, "B", nameof(myArgument), null);
            });
            Assert.Equal(myArgument, result);
        }

        [Fact]
        public void WhenMaximumValueIsNull_ShouldThrowArgumentOutOfRangeException()
        {
            var myArgument = "A";
            var ex = Should.Throw<ArgumentOutOfRangeException>(() =>
            {
                GuardAgainst.ArgumentBeingGreaterThanMaximum(myArgument, null, nameof(myArgument), null);
            });

            ex.ParamName.ShouldBe("myArgument");
        }
    }
}
