using System;
using System.Collections.Generic;
using System.Reflection;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

// ReSharper disable ExpressionIsAlwaysNull

namespace GuardAgainstLib.Test
{
    public class Test_ArgumentBeingLessThanMinimum : TestBase
    {
        public Test_ArgumentBeingLessThanMinimum(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void WhenArgumentIsEqualToMinimum_ShouldNotBeSlow()
        {
            var myArgument = "A";
            Benchmark.Do(() =>
                         {
                             GuardAgainst.ArgumentBeingLessThanMinimum(myArgument, "A", nameof(myArgument), null, new Dictionary<object, object>
                             {
                                 { "a", "1" }
                             });
                         },
                         1000,
                         MethodBase.GetCurrentMethod().Name,
                         Output);
        }

        [Fact]
        public void WhenArgumentIsEqualToMinimum_ShouldNotThrow()
        {
            var myArgument = "A";
            Should.NotThrow(() =>
            {
                GuardAgainst.ArgumentBeingLessThanMinimum(myArgument, "A", nameof(myArgument), null, new Dictionary<object, object>
                {
                    { "a", "1" }
                });
            });
        }

        [Fact]
        public void WhenArgumentIsGreaterThanMinimum_ShouldNotBeSlow()
        {
            var myArgument = "B";
            Benchmark.Do(() =>
                         {
                             GuardAgainst.ArgumentBeingLessThanMinimum(myArgument, "A", nameof(myArgument), null, new Dictionary<object, object>
                             {
                                 { "a", "1" }
                             });
                         },
                         1000,
                         MethodBase.GetCurrentMethod().Name,
                         Output);
        }

        [Fact]
        public void WhenArgumentIsGreaterThanMinimum_ShouldNotThrow()
        {
            var myArgument = "B";
            Should.NotThrow(() =>
            {
                GuardAgainst.ArgumentBeingLessThanMinimum(myArgument, "A", nameof(myArgument), null, new Dictionary<object, object>
                {
                    { "a", "1" }
                });
            });
        }

        [Fact]
        public void WhenArgumentIsLessThanMinimum_ShouldThrowArgumentOutOfRangeException()
        {
            var myArgument = "A";
            var ex = Should.Throw<ArgumentOutOfRangeException>(() =>
            {
                GuardAgainst.ArgumentBeingLessThanMinimum(myArgument, "B", nameof(myArgument), null, new Dictionary<object, object>
                {
                    { "a", "1" }
                });
            });

            ex.ParamName.ShouldBe(nameof(myArgument));
            ex.Data.Count.ShouldBe(1);
            ex.Data["a"].ShouldBe("1");
        }

        [Fact]
        public void WhenArgumentIsNull_ShouldNotThrowException()
        {
            var myArgument = default(string);
            Should.NotThrow(() =>
            {
                GuardAgainst.ArgumentBeingLessThanMinimum(myArgument, "B", nameof(myArgument), null, new Dictionary<object, object>
                {
                    { "a", "1" }
                });
            });
        }

        [Fact]
        public void WhenMinimumValueIsNull_ShouldNotThrow()
        {
            var myArgument = "A";
            Should.NotThrow(() =>
            {
                GuardAgainst.ArgumentBeingLessThanMinimum(myArgument, null, nameof(myArgument), null, new Dictionary<object, object>
                {
                    { "a", "1" }
                });
            });
        }
    }
}
