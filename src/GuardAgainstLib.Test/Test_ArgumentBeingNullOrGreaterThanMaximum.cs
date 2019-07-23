using System;
using System.Collections.Generic;
using System.Reflection;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

// ReSharper disable ExpressionIsAlwaysNull

namespace GuardAgainstLib.Test
{
    public class Test_ArgumentBeingNullOrGreaterThanMaximum : TestBase
    {
        public Test_ArgumentBeingNullOrGreaterThanMaximum(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void WhenArgumentIsEqualToMaximum_ShouldNotBeSlow()
        {
            var myArgument = "A";
            Benchmark.Do(() =>
                         {
                             GuardAgainst.ArgumentBeingNullOrGreaterThanMaximum(myArgument, "A", nameof(myArgument), null, new Dictionary<object, object>
                             {
                                 { "a", "1" }
                             });
                         },
                         1000,
                         MethodBase.GetCurrentMethod().Name,
                         Output);
        }

        [Fact]
        public void WhenArgumentIsEqualToMaximum_ShouldNotThrow()
        {
            var myArgument = "A";
            Should.NotThrow(() =>
            {
                GuardAgainst.ArgumentBeingNullOrGreaterThanMaximum(myArgument, "A", nameof(myArgument), null, new Dictionary<object, object>
                {
                    { "a", "1" }
                });
            });
        }

        [Fact]
        public void WhenArgumentIsGreaterThanMaximum_ShouldThrowArgumentOutOfRangeException()
        {
            var myArgument = "B";
            var ex = Should.Throw<ArgumentOutOfRangeException>(() =>
            {
                GuardAgainst.ArgumentBeingNullOrGreaterThanMaximum(myArgument, "A", nameof(myArgument), null, new Dictionary<object, object>
                {
                    { "a", "1" }
                });
            });

            ex.ParamName.ShouldBe(nameof(myArgument));
            ex.Data.Count.ShouldBe(1);
            ex.Data["a"].ShouldBe("1");
        }

        [Fact]
        public void WhenArgumentIsLessThanMaximum_ShouldNotBeSlow()
        {
            var myArgument = "A";
            Benchmark.Do(() =>
                         {
                             GuardAgainst.ArgumentBeingNullOrGreaterThanMaximum(myArgument, "B", nameof(myArgument), null, new Dictionary<object, object>
                             {
                                 { "a", "1" }
                             });
                         },
                         1000,
                         MethodBase.GetCurrentMethod().Name,
                         Output);
        }

        [Fact]
        public void WhenArgumentIsLessThanMaximum_ShouldNotThrow()
        {
            var myArgument = "A";
            Should.NotThrow(() =>
            {
                GuardAgainst.ArgumentBeingNullOrGreaterThanMaximum(myArgument, "B", nameof(myArgument), null, new Dictionary<object, object>
                {
                    { "a", "1" }
                });
            });
        }

        [Fact]
        public void WhenArgumentIsNull_ShouldThrowArgumentNullException()
        {
            var myArgument = default(string);
            var ex = Should.Throw<ArgumentNullException>(() =>
            {
                GuardAgainst.ArgumentBeingNullOrGreaterThanMaximum(myArgument, "B", nameof(myArgument), null, new Dictionary<object, object>
                {
                    { "a", "1" }
                });
            });

            ex.ParamName.ShouldBe(nameof(myArgument));
            ex.Data.Count.ShouldBe(1);
            ex.Data["a"].ShouldBe("1");
        }

        [Fact]
        public void WhenMaximumValueIsNull_ShouldThrowArgumentNullException()
        {
            var myArgument = "A";
            var ex = Should.Throw<ArgumentOutOfRangeException>(() =>
            {
                GuardAgainst.ArgumentBeingNullOrGreaterThanMaximum(myArgument, null, nameof(myArgument), null, new Dictionary<object, object>
                {
                    { "a", "1" }
                });
            });

            ex.ParamName.ShouldBe("myArgument");
            ex.Data.Count.ShouldBe(1);
        }
    }
}
