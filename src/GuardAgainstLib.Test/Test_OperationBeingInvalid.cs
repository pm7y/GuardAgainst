using System;
using System.Collections.Generic;
using System.Reflection;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

// ReSharper disable ConditionIsAlwaysTrueOrFalse

namespace GuardAgainstLib.Test
{
    public class Test_OperationBeingInvalid : TestBase
    {
        public Test_OperationBeingInvalid(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void WhenArgumentIsFalse_ShouldNotBeSlow()
        {
            var myArgument = false;
            Benchmark.Do(() =>
            {
                GuardAgainst.OperationBeingInvalid(myArgument, null, new Dictionary<object, object> {{"a", "1"}});
            }, 1000, MethodBase.GetCurrentMethod().Name, Output);
        }

        [Fact]
        public void WhenArgumentIsFalse_ShouldNotThrow()
        {
            var myArgument = false;
            Should.NotThrow(() =>
            {
                GuardAgainst.OperationBeingInvalid(myArgument, null, new Dictionary<object, object> {{"a", "1"}});
            });
        }

        [Fact]
        public void WhenArgumentIsTrue_ShouldThrowArgumentException()
        {
            var myArgument = true;
            var ex = Should.Throw<InvalidOperationException>(() =>
            {
                GuardAgainst.OperationBeingInvalid(myArgument, null, new Dictionary<object, object> {{"a", "1"}});
            });

            ex.Data.Count.ShouldBe(1);
            ex.Data["a"].ShouldBe("1");
        }
    }
}
