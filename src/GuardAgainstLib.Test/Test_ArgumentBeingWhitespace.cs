using System;
using System.Collections.Generic;
using System.Reflection;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

// ReSharper disable ExpressionIsAlwaysNull

namespace GuardAgainstLib.Test
{
    public class Test_ArgumentBeingWhitespace : TestBase
    {
        public Test_ArgumentBeingWhitespace(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void WhenArgumentIsNotWhitespace_ShouldNotBeSlow()
        {
            var myArgument = " blah ";
            Benchmark.Do(() =>
            {
                GuardAgainst.ArgumentBeingWhitespace(myArgument, nameof(myArgument), null,
                    new Dictionary<object, object> {{"a", "1"}});
            }, 1000, MethodBase.GetCurrentMethod().Name, Output);
        }

        [Fact]
        public void WhenArgumentIsNotWhitespace_ShouldNotThrow()
        {
            var myArgument = " blah ";
            Should.NotThrow(() =>
            {
                GuardAgainst.ArgumentBeingWhitespace(myArgument, nameof(myArgument), null,
                    new Dictionary<object, object> {{"a", "1"}});
            });
        }

        [Fact]
        public void WhenArgumentIsNull_ShouldNotThrowArgumentNullException()
        {
            var myArgument = default(string);
            Should.NotThrow(() =>
            {
                GuardAgainst.ArgumentBeingWhitespace(myArgument, nameof(myArgument), null,
                    new Dictionary<object, object> {{"a", "1"}});
            });
        }

        [Fact]
        public void WhenArgumentIsWhitespace_ShouldThrowArgumentException()
        {
            var myArgument = "  ";
            var ex = Should.Throw<ArgumentException>(() =>
            {
                GuardAgainst.ArgumentBeingWhitespace(myArgument, nameof(myArgument), null,
                    new Dictionary<object, object> {{"a", "1"}});
            });

            ex.ParamName.ShouldBe(nameof(myArgument));
            ex.Data.Count.ShouldBe(1);
            ex.Data["a"].ShouldBe("1");
        }
    }
}
