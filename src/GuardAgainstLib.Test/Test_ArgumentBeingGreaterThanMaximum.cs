using System;
using System.Collections.Generic;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace GuardAgainstLib.Test
{
    public class Test_ArgumentBeingGreaterThanMaximum : TestBase
    {
        public Test_ArgumentBeingGreaterThanMaximum(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void WhenArgumentIsEqualToMaximum_ShouldNotThrow()
        {
            var myArgument = "A";
            object result = null;
            Should.NotThrow(() =>
            {
                result = GuardAgainst.ArgumentBeingGreaterThanMaximum(myArgument, "A", nameof(myArgument), null,
                    new Dictionary<object, object> {{"a", "1"}});
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
                GuardAgainst.ArgumentBeingGreaterThanMaximum(myArgument, "A", nameof(myArgument), null,
                    new Dictionary<object, object> {{"a", "1"}});
            });

            ex.ParamName.ShouldBe(nameof(myArgument));
            ex.Data.Count.ShouldBe(1);
            ex.Data["a"].ShouldBe("1");
        }
        
        [Fact]
        public void WhenArgumentIsLessThanMaximum_ShouldNotThrow()
        {
            var myArgument = "A";
            object result = null;
            Should.NotThrow(() =>
            {
                result = GuardAgainst.ArgumentBeingGreaterThanMaximum(myArgument, "B", nameof(myArgument), null,
                    new Dictionary<object, object> {{"a", "1"}});
            });
            Assert.NotNull(result);
            Assert.Equal(myArgument, result);
        }

        [Fact]
        public void WhenArgumentIsNull_ShouldNotThrow()
        {
            var myArgument = default(string);
            object result = null;
            Should.NotThrow(() =>
            {
                GuardAgainst.ArgumentBeingGreaterThanMaximum(myArgument, "B", nameof(myArgument), null,
                    new Dictionary<object, object> {{"a", "1"}});
            });
            Assert.Equal(myArgument, result);
        }

        [Fact]
        public void WhenMaximumValueIsNull_ShouldThrowArgumentOutOfRangeException()
        {
            var myArgument = "A";
            var ex = Should.Throw<ArgumentOutOfRangeException>(() =>
            {
                GuardAgainst.ArgumentBeingGreaterThanMaximum(myArgument, null, nameof(myArgument), null,
                    new Dictionary<object, object> {{"a", "1"}});
            });

            ex.ParamName.ShouldBe("myArgument");
            ex.Data.Count.ShouldBe(1);
        }
    }
}
