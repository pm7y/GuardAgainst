using System;
using System.Collections.Generic;
using System.Reflection;
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
        public void WhenArgumentIsEqualToMinimum_ShouldNotBeSlow()
        {
            var myArgument = 1;
            Benchmark.Do(() =>
            {
                GuardAgainst.ArgumentBeingLessThanMinimum(myArgument, 1, nameof(myArgument), null,
                    new Dictionary<object, object> {{"a", "1"}});
            }, 1000, MethodBase.GetCurrentMethod().Name, Output);
        }

        [Fact]
        public void WhenArgumentIsEqualToMinimum_ShouldNotThrow()
        {
            var myArgument = 1;
            Should.NotThrow(() =>
            {
                GuardAgainst.ArgumentBeingLessThanMinimum(myArgument, 1, nameof(myArgument), null,
                    new Dictionary<object, object> {{"a", "1"}});
            });
        }

        [Fact]
        public void WhenArgumentIsGreaterThanMinimum_ShouldNotBeSlow()
        {
            var myArgument = 2;
            Benchmark.Do(() =>
            {
                GuardAgainst.ArgumentBeingLessThanMinimum(myArgument, 1, nameof(myArgument), null,
                    new Dictionary<object, object> {{"a", "1"}});
            }, 1000, MethodBase.GetCurrentMethod().Name, Output);
        }

        [Fact]
        public void WhenArgumentIsGreaterThanMinimum_ShouldNotThrow()
        {
            var myArgument = 2;
            Should.NotThrow(() =>
            {
                GuardAgainst.ArgumentBeingLessThanMinimum(myArgument, 1, nameof(myArgument), null,
                    new Dictionary<object, object> {{"a", "1"}});
            });
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
