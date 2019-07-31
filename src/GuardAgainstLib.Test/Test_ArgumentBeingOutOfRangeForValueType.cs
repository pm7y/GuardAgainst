using System;
using System.Collections.Generic;
using System.Reflection;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace GuardAgainstLib.Test
{
    public class Test_ArgumentBeingOutOfRangeForValueType : TestBase
    {
        public Test_ArgumentBeingOutOfRangeForValueType(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void WhenArgumentIsEqualToMaximum_ShouldNotBeSlow()
        {
            var myArgument = 4;
            Benchmark.Do(() =>
            {
                GuardAgainst.ArgumentBeingOutOfRange(myArgument, 2, 4, nameof(myArgument), null,
                    new Dictionary<object, object> {{"a", "1"}});
            }, 1000, MethodBase.GetCurrentMethod().Name, Output);
        }

        [Fact]
        public void WhenArgumentIsEqualToMaximum_ShouldNotThrow()
        {
            var myArgument = 4;
            Should.NotThrow(() =>
            {
                GuardAgainst.ArgumentBeingOutOfRange(myArgument, 2, 4, nameof(myArgument), null,
                    new Dictionary<object, object> {{"a", "1"}});
            });
        }

        [Fact]
        public void WhenArgumentIsEqualToMinimum_ShouldNotBeSlow()
        {
            var myArgument = 2;
            Benchmark.Do(() =>
            {
                GuardAgainst.ArgumentBeingOutOfRange(myArgument, 2, 4, nameof(myArgument), null,
                    new Dictionary<object, object> {{"a", "1"}});
            }, 1000, MethodBase.GetCurrentMethod().Name, Output);
        }

        [Fact]
        public void WhenArgumentIsEqualToMinimum_ShouldNotThrow()
        {
            var myArgument = 2;
            Should.NotThrow(() =>
            {
                GuardAgainst.ArgumentBeingOutOfRange(myArgument, 2, 4, nameof(myArgument), null,
                    new Dictionary<object, object> {{"a", "1"}});
            });
        }

        [Fact]
        public void WhenArgumentIsGreaterThanMaximum_ShouldThrowArgumentOutOfRangeException()
        {
            var myArgument = 5;
            var ex = Should.Throw<ArgumentOutOfRangeException>(() =>
            {
                GuardAgainst.ArgumentBeingOutOfRange(myArgument, 2, 4, nameof(myArgument), null,
                    new Dictionary<object, object> {{"a", "1"}});
            });

            ex.ParamName.ShouldBe(nameof(myArgument));
            ex.Data.Count.ShouldBe(1);
            ex.Data["a"].ShouldBe("1");
        }

        [Fact]
        public void WhenArgumentIsInRange_ShouldNotBeSlow()
        {
            var myArgument = 3;
            Benchmark.Do(() =>
            {
                GuardAgainst.ArgumentBeingOutOfRange(myArgument, 2, 4, nameof(myArgument), null,
                    new Dictionary<object, object> {{"a", "1"}});
            }, 1000, MethodBase.GetCurrentMethod().Name, Output);
        }

        [Fact]
        public void WhenArgumentIsInRange_ShouldNotThrow()
        {
            var myArgument = 3;
            Should.NotThrow(() =>
            {
                GuardAgainst.ArgumentBeingOutOfRange(myArgument, 2, 4, nameof(myArgument), null,
                    new Dictionary<object, object> {{"a", "1"}});
            });
        }

        [Fact]
        public void WhenArgumentIsLessThanMinimum_ShouldThrowArgumentOutOfRangeException()
        {
            var myArgument = 1;
            var ex = Should.Throw<ArgumentOutOfRangeException>(() =>
            {
                GuardAgainst.ArgumentBeingOutOfRange(myArgument, 2, 4, nameof(myArgument), null,
                    new Dictionary<object, object> {{"a", "1"}});
            });

            ex.ParamName.ShouldBe(nameof(myArgument));
            ex.Data.Count.ShouldBe(1);
            ex.Data["a"].ShouldBe("1");
        }
    }
}
