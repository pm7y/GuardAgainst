using System;
using System.Collections.Generic;
using System.Reflection;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

// ReSharper disable ExpressionIsAlwaysNull
// ReSharper disable ConditionIsAlwaysTrueOrFalse

namespace GuardAgainstLib.Test
{
    public class Test_ArgumentBeingInvalid : TestBase
    {
        public Test_ArgumentBeingInvalid(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void WhenArgumentIsFalse_ShouldNotBeSlow()
        {
            var myArgument = false;
            Benchmark.Do(() =>
                         {
                             GuardAgainst.ArgumentBeingInvalid(myArgument, nameof(myArgument), null, new Dictionary<object, object>
                             {
                                 { "a", "1" }
                             });
                         },
                         1000,
                         MethodBase.GetCurrentMethod().Name,
                         Output);
        }

        [Fact]
        public void WhenArgumentIsFalse_ShouldNotThrow()
        {
            var myArgument = false;
            Should.NotThrow(() =>
            {
                GuardAgainst.ArgumentBeingInvalid(myArgument, nameof(myArgument), null, new Dictionary<object, object>
                {
                    { "a", "1" }
                });
            });
        }

        [Fact]
        public void WhenArgumentIsTrue_ShouldThrowArgumentException()
        {
            var myArgument = true;
            var ex = Should.Throw<ArgumentException>(() =>
            {
                GuardAgainst.ArgumentBeingInvalid(myArgument, nameof(myArgument), null, new Dictionary<object, object>
                {
                    { "a", "1" }
                });
            });

            ex.ParamName.ShouldBe(nameof(myArgument));
            ex.Data.Count.ShouldBe(1);
            ex.Data["a"].ShouldBe("1");
        }
    }
}
