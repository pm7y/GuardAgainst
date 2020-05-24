using System;
using System.Collections.Generic;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace GuardAgainstLib.Test
{
    public class Test_ArgumentBeingLessThanMinimumForValueType : TestBase
    {
        public Test_ArgumentBeingLessThanMinimumForValueType(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void WhenArgumentIsEqualToMinimum_ShouldNotThrow()
        {
            var myArgument = 1;
            object result = null;
            Should.NotThrow(() =>
            {
                result = GuardAgainst.ArgumentBeingLessThanMinimum(myArgument, 1, nameof(myArgument), null,
                    new Dictionary<object, object> {{"a", "1"}});
            });
            Assert.NotNull(result);
            Assert.Equal(myArgument, result);
        }

        [Fact]
        public void WhenArgumentIsGreaterThanMinimum_ShouldNotThrow()
        {
            var myArgument = 2;
            object result = null;
            Should.NotThrow(() =>
            {
                result = GuardAgainst.ArgumentBeingLessThanMinimum(myArgument, 1, nameof(myArgument), null,
                    new Dictionary<object, object> {{"a", "1"}});
            });
            Assert.NotNull(result);
            Assert.Equal(myArgument, result);
        }

        [Fact]
        public void WhenArgumentIsLessThanMinimum_ShouldThrowArgumentOutOfRangeException()
        {
            var myArgument = 1;
            var ex = Should.Throw<ArgumentOutOfRangeException>(() =>
            {
                GuardAgainst.ArgumentBeingLessThanMinimum(myArgument, 2, nameof(myArgument), null,
                    new Dictionary<object, object> {{"a", "1"}});
            });

            ex.ParamName.ShouldBe(nameof(myArgument));
            ex.Data.Count.ShouldBe(1);
            ex.Data["a"].ShouldBe("1");
        }
    }
}
